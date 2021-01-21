//using System;
using JTfy;
using Bridge;
using Retyped;
using Retyped.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;


namespace JSJT
{
    /*internal class App
    {
        internal static void Main()
        {

            var fileContent = new JTfy.JTNode()
            {
                Name = "Test",
                Number = "SomeNumber",

                Attributes = new System.Collections.Generic.Dictionary<string, object>()
                {
                    { "Some string", "str" },
                    { "Some number", 4 },
                    { "Fraction", 4.4f }
                },

                Children = new System.Collections.Generic.List<JTfy.JTNode>()
                {
                    new JTfy.JTNode()
                    {
                        Name = "Test2",
                        Number = "SomeNumber2",
                        Children = new System.Collections.Generic.List<JTfy.JTNode>()
                        {
                             new JTfy.JTNode()
                             {
                                 Name = "Test4",
                                 Number = "SomeNumber4"
                             }
                        }
                    },

                    new JTfy.JTNode()
                    {
                        Name = "Test3",
                        Number = "SomeNumber3",

                        ReferencedFile = @"C:\Users\mtadara1\Desktop\KNUCKLE SUB ASSEMBLY (3).jt"
                    }
                }
            }.ToBytes();

            System.Console.WriteLine(fileContent);
        }
    }*/

    public class Item
    {
        public Retyped.Primitive.String title;
        public es5.Array<Item> children;
        public es5.Array<Number> transformationMatrix;
        public Retyped.Primitive.String filePath;

        public es2015_collection.Map<Retyped.Primitive.String, Retyped.Primitive.Object> attributes;

        public Item parent;
    }

     //[Module(ModuleType.ES6, "Items2JT")]
    //[Module("Items2JT")]
    public static class Items2JT
    {
        public static byte[] Convert(es5.Array<Item> items)
        {
            var rootItems = items.Where(i => i.parent == null).ToArray();

            var rootItem = rootItems.Length == 1 ? rootItems[0] : new { title = "Data", children = rootItems }.As<Item>();

            var rootNode = Item2JTNode(rootItem);

            return rootNode.ToBytes();
        }

        private static JTNode Item2JTNode(Item item)
        {
            Dictionary<string, object> nodeAttributes = null;

            if(item.attributes != null)
            {
                nodeAttributes = new Dictionary<string, object>();

                item.attributes.forEach((value, key, map) => nodeAttributes[key] = value.ValueOf());
            }

            var node = new JTNode()
            {
                Name = item.title,

                TransformationMatrix = item.transformationMatrix?.Select(v => v.As<float>()).ToArray(),

                Children = item.children?.Select(c => Item2JTNode(c)).ToList(),

                ReferencedFile = item.filePath,

                Attributes = nodeAttributes
            };

            return node;
        }

        public static byte[] Test()
        {
            return new JTNode()
            {
                Name = "Test",
                Children = new List<JTNode>()
                {
                    new JTNode()
                    {
                        Name = "Test2"
                    }
                }
            }.ToBytes();
        }
    }
}
