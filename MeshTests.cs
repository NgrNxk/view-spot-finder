using System.Collections.Generic;
using NUnit.Framework;
using ViewSpotFinder.Model;
using Amazon.Lambda.Serialization.SystemTextJson;
using System.IO;

namespace ViewSpotFinder
{
    public class MeshTests
    {
        private Mesh smallMesh = new Mesh
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

        private Mesh bigmesh;


        [SetUp]
        public void Setup()
        {
            using var stream = new FileStream("testdata/mesh.json", FileMode.Open);
            bigmesh = new DefaultLambdaJsonSerializer().Deserialize<Mesh>(stream);
        }

        [Test]
        public void isViewSpot_Returns_False_Given_No_ViewSpot()
        {
            Assert.IsFalse(smallMesh.elements[0].isViewSpot(smallMesh));
        }

        [Test]
        public void isViewSpot_Returns_True_Given_ViewSpot()
        {
            Assert.IsTrue(smallMesh.elements[1].isViewSpot(smallMesh));
        }

        [Test]
        public void ViewSpotFinder_Returns_One_Given_ViewSpot()
        {
			var finder = new Business.ViewSpotFinder(smallMesh);
            Assert.IsTrue(finder.findViewSpots(1).Count == 1);
        }

        [Test]
        public void ViewSpotFinder_Returns_Many_Given_ViewSpot()
        {
			var finder = new Business.ViewSpotFinder(bigmesh);
            var result = finder.findViewSpots(5);
            Assert.IsTrue(result.Count == 5);
        }
    }
}
