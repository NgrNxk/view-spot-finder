using System.Collections.Generic;
using NUnit.Framework;
using ViewSpotFinder.Model;
using Amazon.Lambda.Serialization.SystemTextJson;
using System.IO;
using ViewSpotFinder.Business;

namespace ViewSpotFinder
{
    public class MeshTests
    {
        private InputMesh smallInputMesh = new InputMesh
        {
            nodes = new List<Node> {
                    new Node {
                        id = 0,
                        x = 0,
                        y = 0
                    },
                    new Node {
                        id = 1,
                        x = 0,
                        y = 1
                    },
                    new Node {
                        id = 2,
                        x = 1,
                        y = 1
                    },
                    new Node {
                        id = 3,
                        x = 2,
                        y = 2
                    }
                },
            elements = new List<Element> {
                    new Element() {
                        id = 0,
                        nodes = new List<int> {0,1,2}
                    },
                    new Element() {
                        id = 1,
                        nodes = new List<int> {1,2,3}
                    },
                },
            values = new List<Value> {
                    new Value {
                        element_id = 0,
                        value = 0.0
                    },
                    new Value {
                        element_id = 1,
                        value = 1.0
                    },
                }
        };

        private ParsedMesh bigMesh;
        private ParsedMesh smallMesh;

        [SetUp]
        public void Setup()
        {
            smallMesh = new ParsedMesh(smallInputMesh);

            using var stream = new FileStream("testdata/mesh.json", FileMode.Open);
            bigMesh = new ParsedMesh(new DefaultLambdaJsonSerializer().Deserialize<InputMesh>(stream));
        }

        [Test]
        public void isViewSpot_Returns_False_Given_No_ViewSpot()
        {
            Assert.IsFalse(smallMesh.dElements[0].isViewSpot());
        }

        [Test]
        public void isViewSpot_Returns_True_Given_ViewSpot()
        {
            Assert.IsTrue(smallMesh.dElements[1].isViewSpot());
        }

        [Test]
        public void ViewSpotFinder_Returns_One_Given_SmallMesh_And_One()
        {
			var finder = new Business.ViewSpotFinder(smallMesh);
            Assert.IsTrue(finder.findViewSpots(1).Count == 1);
        }

        [Test]
        public void ViewSpotFinder_Returns_Five_Given_BigMesh_And_Five()
        {
			var finder = new Business.ViewSpotFinder(bigMesh);
            var result = finder.findViewSpots(5);
            Assert.IsTrue(result.Count == 5);
        }
    }
}
