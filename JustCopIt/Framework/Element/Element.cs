namespace JustCopIt.Framework.Element
{
   public abstract class Element
    {
      public string Name { get; set; }

       protected Element(string name)
       {
           Name = name;
       }
    }
   public class ClickElement : Element
   {
       public ClickElement(string name): base(name){}
   }

   public class SetElement : Element
   {
       public string Value { get; set; }

       public SetElement(string name, string value): base(name)
       {
           Value = value;
       }
   }

   public class CheckElement : Element
   {
       public CheckElement(string name): base(name){}
   }
}
