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

        private void Pack(double containerWidth, double containerHeight)
        {
            //boxes = boxes.OrderByDescending(x => x.area).ToList();
            rootNode = new Node { width = containerWidth, height = containerHeight };

            foreach (var element in Elements)
            {
                var node = SearchForNode(rootNode, element.width, element.height); //Проверяем, можно ли в rootNode вместить элемент
                if (node != null)
                {
                    element.position = GetSpace(node, element.width, element.height); //Определение свободного пространства для последующего размещения элементов
                }
                else
                {
                    element.position = Grow(element.width, element.height);
                }
            }
        }

        private Node SearchForNode(Node rootNode, double width, double height)
        {
            if (rootNode.used)
            {
                var nextNode = SearchForNode(rootNode.right, width, height);

                if (nextNode == null)
                {
                    nextNode = SearchForNode(rootNode.down, width, height);
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

        private Node GetSpace(Node thisNode, double ewidth, double eheight)
        {
            thisNode.used = true;
            thisNode.down = new Node { x = thisNode.x, y = thisNode.y + eheight, width = thisNode.width, height = thisNode.height - eheight };
            thisNode.right = new Node { x = thisNode.x + ewidth, y = thisNode.y, width = thisNode.width - ewidth, height = eheight };
            return thisNode;
        }

        private Node Grow(double width, double height)
        {
            bool goDown = (height <= rootNode.height);
            bool goRight = (width <= rootNode.width);

            bool mustGoRight = goRight && (rootNode.width >= (rootNode.width + width));
            bool mustGoDown = goDown && (rootNode.height >= (rootNode.height + height));

            if (mustGoRight)
            {

                return GoRight(width, height);
            }
            else if (mustGoDown)
            {

                return GoDown(width, height);
            }
            else if (goRight)
            {

                return GoRight(width, height);
            }
            else if (goDown)
            {

                return GoDown(width, height);
            }
            else
            {

                return null;
            }
        }

        private Node GoRight(double width, double height)
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

            Node node = SearchForNode(rootNode, width, height);
            if (node != null)
            {
                return GetSpace(node, width, height);
            }
            else
            {
                return null;
            }
        }

        private Node GoDown(double width, double height)
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
            Node node = SearchForNode(rootNode, width, height);
            if (node != null)
            {
                return GetSpace(node, width, height);
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
