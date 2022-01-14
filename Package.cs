﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementPackageTask
{
    public class Package
    {
        public class Node 
        {
            public Node nodeRight;
            public Node nodeBottom;
            public double x;
            public double y;
            public double width;
            public double height;
            public bool isUsed;
        }

        public class Element
        {
            public double width;
            public double height;
            public double volume;
            public Node coordinate;
        }

        private double PCBWidth = 220;
        private double PCBHeight = 250;
        public List<Element> Elements;
        private Node root;

        public Package()
        {
           
        }
        public void PackageStart()
        {
            Elements = new List<Element>();
            /*Element element1 = new Element { width = 6, height = 10 };
            Element element2 = new Element { width = 6, height = 5 };
            Element element3 = new Element { width = 6, height = 5 };
            Element element4 = new Element { width = 6, height = 5 };
            Element element5 = new Element { width = 4, height = 4 };
            Element element6 = new Element { width = 2, height = 4 };
            Element element7 = new Element { width = 6, height = 6 };
            Element element8 = new Element { width = 6, height = 6 };
            Element element9 = new Element { width = 6, height = 6 };*/

            Element element1 = new Element { width = 60, height = 100 };
            Element element2 = new Element { width = 60, height = 50 };
            Element element3 = new Element { width = 60, height = 50 };
            Element element4 = new Element { width = 60, height = 50 };
            Element element5 = new Element { width = 40, height = 40 };
            Element element6 = new Element { width = 20, height = 40 };
            Element element7 = new Element { width = 60, height = 60 };
            Element element8 = new Element { width = 60, height = 60 };
            Element element9 = new Element { width = 60, height = 60 };

            Elements.Add(element1);
            Elements.Add(element2);
            Elements.Add(element3);
            Elements.Add(element4);
            Elements.Add(element5);
            Elements.Add(element6);
            Elements.Add(element7);
            Elements.Add(element8);
            Elements.Add(element9);

            Elements.ForEach(item => item.volume = (item.width * item.height));
            //Elements = Elements.OrderByDescending(item => item.volume).ToList();

            root = new Node { height = PCBHeight, width = PCBWidth };

            MakePackage();
            //PrintResult();
            //Console.ReadLine();
        }

        private void PrintResult()
        {
            foreach (var item in Elements)
            {
                var x = item.coordinate.x.ToString();
                var y = item.coordinate.y.ToString();

                Console.WriteLine("Height : " + item.height + " Width : " + item.width + " Pos_x  : " + x + " Pos_y : " + y);
            }
        }

        private void MakePackage()
        {
            foreach (var item in Elements)
            { 
            var node = FindNode(root, item.width, item.height);
                if (node != null)
                {
                    // Split rectangles
                    item.coordinate = BorderNode(node, item.width, item.height);
                }
            }
        }

        private Node FindNode(Node root, double width, double height)
        {
            if (root.isUsed)
            {
                var nextNode = FindNode(root.nodeBottom, width, height);

                if (nextNode == null)
                {
                    nextNode = FindNode(root.nodeRight, width, height);
                }

                return nextNode;
            }
            else if (width <= root.width && height <= root.height)
            {
                return root;
            }
            else
            {
                return null;
            }
        }

        private Node BorderNode(Node node, double width, double height)
        {
            node.isUsed = true;
            node.nodeBottom = new Node { y = node.y, x = node.x + width, height = node.height, width = node.width - width };
            node.nodeRight = new Node { y = node.y + height, x = node.x, height = node.height - height, width = width };
            return node;

        }
    }
}
