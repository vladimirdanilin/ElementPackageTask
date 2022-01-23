using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementPackageTask
{
    public class Package
    {
        public Package()
        {

        }
        public class Node
        {
            public Node right;
            public Node down;
            public double x;
            public double y;
            public double width;
            public double height;
            public bool used;
        }

        public List<Element> Elements = new List<Element>();
        public List<Element> ElementsExtra = new List<Element>(); //Хранит исходный порядок элементов

        public class Element
        {
            public double height;
            public double width;
            public double area;
            public Node position;
        }

        private Node rootNode;

        public void PackageStart(double[,] elementSize, int[] sequenceOfElements, double containerWidth, double containerHeight)
        {
            Elements = new List<Element>();

            for (int i = 0; i < elementSize.Length / 2; i++)
            {
                Element element = new Element { width = elementSize[i, 0], height = elementSize[i, 1] };
                element.area = element.width * element.height;
                Elements.Add(element);
            }

            ElementsExtra.AddRange(Elements);

            for (int i = 0; i < sequenceOfElements.Length; i++)
            {
                Elements[i] = ElementsExtra[sequenceOfElements[i]];
            }

            Pack(containerWidth, containerHeight);
        }

        public void Pack(double containerWidth, double containerHeight)
        {
            //boxes = boxes.OrderByDescending(x => x.area).ToList();
            rootNode = new Node { width = containerWidth, height = containerHeight };

            foreach (var element in Elements)
            {
                var node = FindNode(rootNode, element.width, element.height); //Проверяем, можно ли в rootNode вместить элемент
                if (node != null)
                {
                    element.position = SplitNode(node, element.width, element.height); //Определение свободного пространства для последующего размещения элементов
                }
                else
                {
                    element.position = GrowNode(element.width, element.height);
                }
            }
        }

        private Node FindNode(Node rootNode, double width, double height)
        {
            if (rootNode.used)
            {
                var nextNode = FindNode(rootNode.right, width, height);

                if (nextNode == null)
                {
                    nextNode = FindNode(rootNode.down, width, height);
                }

                return nextNode;
            }
            else if (width <= rootNode.width && height <= rootNode.height)
            {
                return rootNode;
            }
            else
            {
                return null;
            }
        }

        private Node SplitNode(Node node, double ewidth, double eheight)
        {

            node.used = true;
            node.down = new Node { x = node.x, y = node.y + eheight, width = node.width, height = node.height - eheight };
            node.right = new Node { x = node.x + ewidth, y = node.y, width = node.width - ewidth, height = eheight };
            return node;
        }

        private Node GrowNode(double width, double height)
        {
            bool canGrowDown = (height <= rootNode.height);
            bool canGrowRight = (width <= rootNode.width);

            bool shouldGrowRight = canGrowRight && (rootNode.width >= (rootNode.width + width));
            bool shouldGrowDown = canGrowDown && (rootNode.height >= (rootNode.height + height));

            if (shouldGrowRight)
            {

                return growRight(width, height);
            }
            else if (shouldGrowDown)
            {

                return growDown(width, height);
            }
            else if (canGrowRight)
            {

                return growRight(width, height);
            }
            else if (canGrowDown)
            {

                return growDown(width, height);
            }
            else
            {

                return null;
            }
        }

        private Node growRight(double width, double height)
        {
            rootNode = new Node()
            {
                used = true,
                x = 0,
                y = 0,
                width = rootNode.width + width,
                height = rootNode.height,
                down = rootNode,
                right = new Node() { x = rootNode.width, y = 0, width = width, height = rootNode.height }
            };

            Node node = FindNode(rootNode, width, height);
            if (node != null)
            {
                return SplitNode(node, width, height);
            }
            else
            {
                return null;
            }
        }

        private Node growDown(double width, double height)
        {
            rootNode = new Node()
            {
                used = true,
                x = 0,
                y = 0,
                width = rootNode.width,
                height = rootNode.height + height,
                down = new Node() { x = 0, y = rootNode.height, width = rootNode.width, height = height },
                right = rootNode
            };
            Node node = FindNode(rootNode, width, height);
            if (node != null)
            {
                return SplitNode(node, width, height);
            }
            else
            {
                return null;
            }
        }

        public void PrintList(List<Element> list, string text)
        {
            Console.WriteLine(text);
            foreach (var item in list)
            {
                Console.WriteLine($"W = {item.width} H = {item.height} X = {item.position.x} Y = {item.position.y}");
            }
        }
    }
}
