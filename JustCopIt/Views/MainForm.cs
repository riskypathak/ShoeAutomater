
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using JustCopIt.Common;
using JustCopIt.Enumeration;
using JustCopIt.Framework.Model;
using JustCopIt.Logging;
using JustCopIt.UserControls;
using JustCopIt.Util;
using wyDay.TurboActivate;

namespace JustCopIt.Views
{
    public partial class MainForm : Form
    {
        #region Declarations

        private readonly UILogging _uiLogging;
        private Dictionary<SiteType, bool> _dictStopTracking;
        private readonly Dictionary<SiteType, TabPage> _dictTabViewCart;
        private readonly Dictionary<SiteType, CartView> _dictCartViewControl;

        private readonly Color SuccessTextBoxColor = Color.LightGreen;
        private readonly Color ErrorTextBoxColor = Color.Red;
        bool isActivated;
        #endregion

        #region Constructor

        public MainForm()
        {
            Constants.IsReset = false;

            InitializeComponent();
            _uiLogging = new UILogging(rtxtLog);
            _dictTabViewCart = new Dictionary<SiteType, TabPage>
            {
                {SiteType.ChampsSports, tabChampsSports},
                {SiteType.Eastbay, tabEastbay},
                {SiteType.Footaction, tabFootaction},
                {SiteType.FootLocker, tabFootLocker}
            };
            _dictCartViewControl = new Dictionary<SiteType, CartView>
            {
                {SiteType.ChampsSports,cartViewChampsSports},
                {SiteType.Eastbay, cartViewEastbay},
                {SiteType.Footaction, cartViewFootaction},
                {SiteType.FootLocker, cartViewFootLocker}
            };

            //Build click-once
            isActivated = true;
            //Build wyday
            //RegisterTurboActivate();
        }

        #region Activate

        private void RegisterTurboActivate()
        {
            //TODO: goto the version page at LimeLM and paste this GUID here
            TurboActivate.VersionGUID = "ea47f8154f93260b389f5.40653018";

            try
            {
                // Check if we're activated, and every 90 days verify it with the activation servers
                // In this example we won't show an error if the activation was done offline
                // (see the 3rd parameter of the IsGenuine() function) -- http://wyday.com/limelm/help/offline-activation/
                IsGenuineResult gr = TurboActivate.IsGenuine(90, 14, true);

                isActivated = gr == IsGenuineResult.Genuine ||
                              gr == IsGenuineResult.GenuineFeaturesChanged ||

                              // an internet error means the user is activated but
                    // TurboActivate failed to contact the LimeLM servers
                              gr == IsGenuineResult.InternetError;

                if (gr == IsGenuineResult.InternetError)
                {
                    //TODO: give the user the option to retry the genuine checking immediately
                    //      For example a dialog box. In the dialog call IsGenuine() to retry immediately
                    MessageBox.Show(@"Internet error", Constants.ApplicationTitle);
                    isActivated = false;
                }
            }
            catch (TurboActivateException ex)
            {
                MessageBox.Show(@"Failed to check if activated: " + ex.Message);
                isActivated = false;
            }
        }
        #endregion

        #endregion


        #region Validate

        private bool ValidateUrl(string url, string host)
        {
            return DataUtil.IsNullOrEmptyOrWhiteSpace(url) || url.StartsWith(host);
        }

        private bool ValidateSingleSite(SiteType type)
        {
            var isValidUrl = false;
            var isValidSize = true;
            switch (type)
            {
                case SiteType.ChampsSports:
                    isValidUrl = ValidateUrl(txtChampUrl.Text, MockData.ChampsSportsHost);
                    isValidSize = !string.IsNullOrEmpty(DataUtil.StringForNull(cboChampSize.SelectedValue));
                    break;
                case SiteType.Eastbay:
                    isValidUrl = ValidateUrl(txtEastbayUrl.Text, MockData.EastbayViewHost);
                    isValidSize = !string.IsNullOrEmpty(DataUtil.StringForNull(cboEastbaySize.SelectedValue));
                    break;
                case SiteType.Footaction:
                    isValidUrl = ValidateUrl(txtFootactionUrl.Text, MockData.FootactioHost);
                    isValidSize = !string.IsNullOrEmpty(DataUtil.StringForNull(cboFootactionSize.SelectedValue));
                    break;
                case SiteType.FootLocker:
                    isValidUrl = ValidateUrl(txtFootLockerUrl.Text, MockData.FootLockerHost);
                    isValidSize = !string.IsNullOrEmpty(DataUtil.StringForNull(cboFootLockerSize.SelectedValue));
                    break;
            }
            if (!isValidUrl)
            {
                //if in valid url, skip size
                isValidSize = true;
            }
            ShowHideNotifyError(type, !isValidUrl, !isValidSize);
            return isValidUrl && isValidSize;
        }

        private void SetUrlError(TextBox txt, bool isError)
        {
            txt.ForeColor = isError ? Color.Red : Color.Black;
        }
        private void SetSizeError(Label lbl, bool isError)
        {
            //lbl.ForeColor = isError ? Color.Red : Color.Black;
        }

        private void ShowHideNotifyError(SiteType type, bool isErrorUrl, bool IsErrorSize)
        {
            switch (type)
            {
                case SiteType.ChampsSports:
                    SetUrlError(txtChampUrl, isErrorUrl);
                    SetSizeError(lblChamp, IsErrorSize);
                    break;
                case SiteType.Eastbay:
                    SetUrlError(txtEastbayUrl, isErrorUrl);
                    SetSizeError(lblEastbay, IsErrorSize);
                    break;
                case SiteType.Footaction:
                    SetUrlError(txtFootactionUrl, isErrorUrl);
                    SetSizeError(lblFootaction, IsErrorSize);
                    break;
                case SiteType.FootLocker:
                    SetUrlError(txtFootLockerUrl, isErrorUrl);
                    SetSizeError(lblFootLocker, IsErrorSize);
                    break;
            }
        }

        private bool ValidateInputTextboxes()
        {
            if (DataUtil.IsAllEmpty(txtChampUrl.Text, txtEastbayUrl.Text, txtFootactionUrl.Text, txtFootLockerUrl.Text))
                return false;

            var isValidChampsSports = ValidateSingleSite(SiteType.ChampsSports);
            var isValidEastbay = ValidateSingleSite(SiteType.Eastbay);
            var isValidFootaction = ValidateSingleSite(SiteType.Footaction);
            var isValidFootLocker = ValidateSingleSite(SiteType.FootLocker);

            return isValidChampsSports && isValidEastbay && isValidFootaction && isValidFootLocker;
        }

        #endregion

        #region Init Data

        private void SetVersion()
        {
            //lblVersion.Text = GetVersion();
        }

        private void SetSizeSource()
        {
            var sizes = SizeSource.Data;
            cboChampSize.DataSource = new List<string>(sizes);
            cboEastbaySize.DataSource = new List<string>(sizes);
            cboFootactionSize.DataSource = new List<string>(sizes);
            cboFootLockerSize.DataSource = new List<string>(sizes);

            //cboChampSize.SelectedIndex = sizes.IndexOf(MockData.ChampsSportsDefaultSize);
            //cboEastbaySize.SelectedIndex = sizes.IndexOf(MockData.EastbayDefaultSize);
            //cboFootactionSize.SelectedIndex = sizes.IndexOf(MockData.FootactionDefaultSize);
            //cboFootLockerSize.SelectedIndex = sizes.IndexOf(MockData.FootLockerDefaultSize);

            cboChampSize.SelectedIndex = 0;
            cboEastbaySize.SelectedIndex = 0;
            cboFootactionSize.SelectedIndex = 0;
            cboFootLockerSize.SelectedIndex = 0;
        }

        private void SetTestUrl()
        {
            //Test;
            //txtChampUrl.Text = MockData.ChampsSportsUrl;
            //txtEastbayUrl.Text = MockData.EastbayUrl;
            //txtFootactionUrl.Text = MockData.FootactionUrl;
            //txtFootLockerUrl.Text = MockData.FootLockerUrl;
            //Test;
            txtChampUrl.Text = string.Empty;
            txtEastbayUrl.Text = string.Empty;
            txtFootactionUrl.Text = string.Empty;
            txtFootLockerUrl.Text = string.Empty;
        }

        private void SetCartViewsLog()
        {
            foreach (var cartViewPair in _dictCartViewControl)
            {
                cartViewPair.Value.SpiderLogging = _uiLogging;
            }
        }

        #endregion

        #region Control Status

        private void SetDefaultStatus()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            btnChampViewCart.Enabled = false;
            btnEastbayViewCart.Enabled = false;
            btnFootactionViewCart.Enabled = false;
            btnFootLockerViewCart.Enabled = false;

            txtChampUrl.BackColor = DefaultBackColor;
            txtEastbayUrl.BackColor = DefaultBackColor;
            txtFootactionUrl.BackColor = DefaultBackColor;
            txtFootLockerUrl.BackColor = DefaultBackColor;

            txtChampUrl.ForeColor = DefaultForeColor;
            txtEastbayUrl.ForeColor = DefaultForeColor;
            txtFootactionUrl.ForeColor = DefaultForeColor;
            txtFootLockerUrl.ForeColor = DefaultForeColor;

            // UpdateProgessBarValue(0);
            StartStopProgessBar(false);

            txtChampUrl.Focus();
            //invisible tab
            ShowHideMultiTabPages(false, tabChampsSports, tabEastbay, tabFootaction, tabFootLocker);
            SetTestUrl();

        }

        private void ShowHideTabPage(bool isVisible, TabPage tab)
        {
            //if (isVisible)
            //{
            //    if (tabControlSpider.Contains(tab)) return;
            //    tabControlSpider.TabPages.Add(tab);
            //}
            //else
            //{
            //    if (!tabControlSpider.Contains(tab)) return;
            //    tabControlSpider.TabPages.Remove(tab);
            //}
            tab.Enabled = isVisible;
        }

        private void ShowHideMultiTabPages(bool isVisible, params TabPage[] tabs)
        {
            if (tabs == null || tabs.Length == 0) return;
            foreach (var tabPage in tabs)
            {
                ShowHideTabPage(isVisible, tabPage);
            }
            tabControlSpider.Invalidate();
        }

        #endregion

        #region Main Methods


        private Dictionary<SiteType, SiteModel> GetAvailableSites()
        {
            if (DataUtil.IsAllEmpty(txtChampUrl.Text, txtEastbayUrl.Text, txtFootactionUrl.Text, txtFootLockerUrl.Text))
                return null;
            var dict = new Dictionary<SiteType, SiteModel>
            {
                {SiteType.ChampsSports, new SiteModel(SiteType.ChampsSports,false,ExtractValidUrl(txtChampUrl.Text),DataUtil.StringForNull(cboChampSize.SelectedValue))},
                {SiteType.Eastbay, new SiteModel(SiteType.Eastbay,false,ExtractValidUrl(txtEastbayUrl.Text),DataUtil.StringForNull(cboEastbaySize.SelectedValue))},
                {SiteType.Footaction, new SiteModel(SiteType.Footaction,false,txtFootactionUrl.Text,DataUtil.StringForNull(cboFootactionSize.SelectedValue))},
                {SiteType.FootLocker, new SiteModel(SiteType.FootLocker,false,txtFootLockerUrl.Text,DataUtil.StringForNull(cboFootLockerSize.SelectedValue))}
            };
            foreach (var pair in dict)
            {
                pair.Value.IsValid = ValidateSingleSite(pair.Key);
            }
            return dict;
        }

        private string ExtractValidUrl(string inputUrl)
        {
            if (string.IsNullOrEmpty(inputUrl)) return inputUrl;
            return inputUrl.Contains("?") ? inputUrl.Substring(0, inputUrl.IndexOf("?", StringComparison.Ordinal)) : inputUrl;
        }

        private void StartProject()
        {

            var dict = GetAvailableSites();
            if (dict == null || dict.Count == 0)
            {
                MessageBox.Show(@"Please input Urls.", Constants.ApplicationTitle);
                return;
            }
            if (dict.Any(e => !e.Value.IsValid))
            {
                var count = dict.Count(e => !e.Value.IsValid);
                MessageBox.Show(
                    count == 1
                        ? @"There is a invalid url or size, please check it."
                        : string.Format("There are {0} invalid urls or sizes, please check them.", count),
                    Constants.ApplicationTitle);

                return;
            }

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            txtChampUrl.BackColor = DefaultBackColor;
            txtEastbayUrl.BackColor = DefaultBackColor;
            txtFootactionUrl.BackColor = DefaultBackColor;
            txtFootLockerUrl.BackColor = DefaultBackColor;

            ShowHideMultiTabPages(false, tabChampsSports, tabEastbay, tabFootaction, tabFootLocker);
            _dictStopTracking = new Dictionary<SiteType, bool>();

            if (dict.Any(site => site.Value != null && site.Value.IsPageModel()))
            {
                _uiLogging.Write("Start Project");
                StartMultiSites(dict);
            }
        }

        private void DeleteCookies(IEnumerable<string> Cookies, PageModel page)
        {
            var success = false;
            try
            {
                foreach (var CookieFile in Cookies)
                {
                    if (FileHelper.CheckExistCookieFromFile(CookieFile, page.CookieName))
                    {
                        System.IO.File.Delete(CookieFile);
                        success = true;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                success = false;
                _uiLogging.Write(string.Format("Cannot deleted {0} cookies - required permission", page.Type));
            }
            catch (Exception)
            {
                success = false;
                _uiLogging.Write(string.Format("Cannot deleted {0} cookies", page.Type));
            }
            finally
            {
                if (success)
                {
                    _uiLogging.Write(string.Format("Deleted {0} cookies", page.Type));
                }
            }
        }

        private void StartMultiSites(Dictionary<SiteType, SiteModel> dict)
        {
            try
            {
                //timerProcess.Start();
                if (dict.Count == 0) return;
                //UpdateProgessBarValue(1);
                _uiLogging.Write("Deleting cookies...");
                string[] cookies = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
                foreach (var site in dict)
                {
                    if (site.Value != null && site.Value.IsPageModel())
                    {
                        StartStopProgessBar(true);
                        _dictStopTracking.Add(site.Key, false);
                        DeleteCookies(cookies, site.Value.PageModel);
                        StartSite(site.Key, site.Value.PageModel);
                    }
                }
            }
            catch (Exception ex)
            {
                _uiLogging.Write(ex.Message);
            }

        }

        private void StartSite(SiteType type, PageModel pageModel)
        {
            var cartView = _dictCartViewControl.FirstOrDefault(p => p.Key == type).Value;
            switch (type)
            {
                case SiteType.ChampsSports:
                    txtChampUrl.BackColor = DefaultBackColor;
                    cartView.CartViewCompletedEvent += ChampsSports_CartViewCompletedEvent;
                    break;
                case SiteType.Eastbay:
                    txtEastbayUrl.BackColor = DefaultBackColor;
                    cartView.CartViewCompletedEvent += Eastbay_CartViewCompletedEvent;
                    break;
                case SiteType.Footaction:
                    txtFootactionUrl.BackColor = DefaultBackColor;
                    cartView.CartViewCompletedEvent += Footaction_CartViewCompletedEvent;
                    break;
                case SiteType.FootLocker:
                    txtFootLockerUrl.BackColor = DefaultBackColor;
                    cartView.CartViewCompletedEvent += FootLocker_CartViewCompletedEvent;
                    break;
            }
            cartView.Start(pageModel);
        }

        private void RestartSite(SiteType type)
        {
            _uiLogging.Write(string.Format("{0} - {1}", type, "Restart..."));
            var cartView = _dictCartViewControl.FirstOrDefault(p => p.Key == type).Value;
            switch (type)
            {
                case SiteType.ChampsSports:
                    txtChampUrl.BackColor = DefaultBackColor;
                    cartView.CartViewCompletedEvent += ChampsSports_CartViewCompletedEvent;
                    break;
                case SiteType.Eastbay:
                    txtEastbayUrl.BackColor = DefaultBackColor;
                    cartView.CartViewCompletedEvent += Eastbay_CartViewCompletedEvent;
                    break;
                case SiteType.Footaction:
                    txtFootactionUrl.BackColor = DefaultBackColor;
                    cartView.CartViewCompletedEvent += Footaction_CartViewCompletedEvent;
                    break;
                case SiteType.FootLocker:
                    txtFootLockerUrl.BackColor = DefaultBackColor;
                    cartView.CartViewCompletedEvent += FootLocker_CartViewCompletedEvent;
                    break;
            }
            cartView.Restart();
        }


        private void ShowViewCartResult(SiteType type)
        {
            var tabPage = _dictTabViewCart.FirstOrDefault(p => p.Key == type).Value;
            ShowHideTabPage(true, tabPage);
            tabControlSpider.SelectedTab = tabPage;
        }

        private void StartStopProgessBar(bool isStart )
        {
            progressBar.Style = isStart ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
        }


        private void Stop()
        {
            timerProcess.Stop();
            StartStopProgessBar(false);
            if (_dictStopTracking != null)
            {
                _dictStopTracking.Clear();
            }
            foreach (var cartViewPair in _dictCartViewControl)
            {
                var cartView = cartViewPair.Value;
                cartView.Stop();
                switch (cartViewPair.Key)
                {
                    case SiteType.ChampsSports:
                        cartView.CartViewCompletedEvent -= ChampsSports_CartViewCompletedEvent;
                        break;
                    case SiteType.Eastbay:
                        cartView.CartViewCompletedEvent -= Eastbay_CartViewCompletedEvent;
                        break;
                    case SiteType.Footaction:
                        cartView.CartViewCompletedEvent -= Footaction_CartViewCompletedEvent;
                        break;
                    case SiteType.FootLocker:
                        cartView.CartViewCompletedEvent -= FootLocker_CartViewCompletedEvent;
                        break;
                }
            }
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }

        private void ClearLog()
        {
            rtxtLog.Invoke((MethodInvoker)(() => rtxtLog.Text = string.Empty));
        }
        private void Reset()
        {
            ShowHideMultiTabPages(false, tabChampsSports, tabEastbay, tabFootaction, tabFootLocker);
            tabControlSpider.SelectedTab = tabMain;
            foreach (var cartViewPair in _dictCartViewControl)
            {
                cartViewPair.Value.Clear();
            }
            Stop();
            SetSizeSource();
            SetDefaultStatus();
            ClearLog();
        }
        private void Exit()
        {
           // _uiLogging.StopLogging();
            Application.Exit();
        }

        //private void UpdateProgessBarValue(int value)
        //{
        //    if (value < 0)
        //    {
        //        progressBarAll.Value = 0;
        //        return;
        //    }
        //    if (value > 100)
        //    {
        //        progressBarAll.Value = 100;
        //        return;
        //    }
        //    progressBarAll.Value = value;
        //}

        //private int GetTrackingProgess()
        //{
        //    if (_dictStopTracking == null ) return 0;
        //    var remain = _dictStopTracking.Count - _dictStopTracking.Count(p => p.Value);
        //    if (remain <= 0) return 0;
        //    var progressBarValueRemaining = progressBarAll.Maximum - progressBarAll.Value;
        //    if (progressBarValueRemaining <= 0) return 100;
        //    return progressBarAll.Value + progressBarValueRemaining/remain;
        //}
        #endregion

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.TopMost = false;

            SetVersion();
            SetSizeSource();
            SetDefaultStatus();
            SetCartViewsLog();
            if (!isActivated)
            {
                Exit();
            }
            //toolStripProgressBar1.Style=ProgressBarStyle.Marquee;
        }

        private void tabControlSpider_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!e.TabPage.Enabled)
            {
                e.Cancel = true;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox != null)
            {
                ValidateInputTextboxes();
            }
        }

        private void TimerProcess_Tick(object sender, EventArgs e)
        {
            //progressBarAll.Increment(1);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartProject();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"This will reset all of the bot’s settings and clear all carts.", Constants.ApplicationTitle, MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Reset();

                Constants.IsReset = true;
                //_uiLogging.StopLogging();
                this.Dispose();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Are you sure you want to exit?", Constants.ApplicationTitle, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Exit();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exit();
        }

        private void btnChampViewCart_Click(object sender, EventArgs e)
        {
            ShowViewCartResult(SiteType.ChampsSports);
        }

        private void btnEastbayViewCart_Click(object sender, EventArgs e)
        {
            ShowViewCartResult(SiteType.Eastbay);
        }

        private void btnFootactionViewCart_Click(object sender, EventArgs e)
        {
            ShowViewCartResult(SiteType.Footaction);
        }

        private void btnFootLockerViewCart_Click(object sender, EventArgs e)
        {
            ShowViewCartResult(SiteType.FootLocker);
        }

        private void TrackSiteInAllTasks(SiteType type, bool status)
        {
            if (_dictStopTracking == null || _dictStopTracking.Count <= 0) return;

            if (_dictStopTracking.ContainsKey(type))
            {
                _dictStopTracking[type] = status;
                //UpdateProgessBarValue(GetTrackingProgess());
            }
            if (_dictStopTracking.All(p => p.Value))
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                //UpdateProgessBarValue(100);
                StartStopProgessBar(false);
            }

        }

        private void TrackTaskDone(SiteType type, bool status)
        {
            switch (type)
            {
                case SiteType.ChampsSports:
                    btnChampViewCart.Enabled = status;
                    txtChampUrl.BackColor = status ? SuccessTextBoxColor : ErrorTextBoxColor;
                    ShowHideTabPage(status, tabChampsSports);
                    break;
                case SiteType.Eastbay:
                    btnEastbayViewCart.Enabled = status;
                    txtEastbayUrl.BackColor = status ? SuccessTextBoxColor : ErrorTextBoxColor;
                    ShowHideTabPage(status, tabEastbay);
                    break;
                case SiteType.Footaction:
                    btnFootactionViewCart.Enabled = status;
                    txtFootactionUrl.BackColor = status ? SuccessTextBoxColor : ErrorTextBoxColor;
                    ShowHideTabPage(status, tabFootaction);
                    break;
                case SiteType.FootLocker:
                    btnFootLockerViewCart.Enabled = status;
                    txtFootLockerUrl.BackColor = status ? SuccessTextBoxColor : ErrorTextBoxColor;
                    ShowHideTabPage(status, tabFootLocker);
                    break;
            }
            TrackSiteInAllTasks(type, status);

        }

        private void FootLocker_CartViewCompletedEvent(object sender, bool result)
        {
            var cartView = sender as CartView;
            if (cartView == null) return;
            cartView.CartViewCompletedEvent -= FootLocker_CartViewCompletedEvent;
            const SiteType type = SiteType.FootLocker;
            TrackTaskDone(type, result);
            if (!result)
            {
                cartView.Stop();
                RestartSite(type);
            }
        }

        private void Footaction_CartViewCompletedEvent(object sender, bool result)
        {
            var cartView = sender as CartView;
            if (cartView == null) return;
            cartView.CartViewCompletedEvent -= Footaction_CartViewCompletedEvent;
            const SiteType type = SiteType.Footaction;
            TrackTaskDone(type, result);
            if (!result)
            {
                RestartSite(type);
            }
        }

        private void Eastbay_CartViewCompletedEvent(object sender, bool result)
        {
            var cartView = sender as CartView;
            if (cartView == null) return;
            cartView.CartViewCompletedEvent -= Eastbay_CartViewCompletedEvent;
            const SiteType type = SiteType.Eastbay;
            TrackTaskDone(type, result);
            if (!result)
            {
                RestartSite(type);
            }
        }

        private void ChampsSports_CartViewCompletedEvent(object sender, bool result)
        {
            var cartView = sender as CartView;
            if (cartView == null) return;
            cartView.CartViewCompletedEvent -= ChampsSports_CartViewCompletedEvent;
            const SiteType type = SiteType.ChampsSports;
            TrackTaskDone(type, result);
            if (!result)
            {
                RestartSite(type);
            }
        }

        #endregion

        #region Version

        private string GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return string.Format("Version: {0}", version);
        }

        #endregion



    }
}
