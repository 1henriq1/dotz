using Dotz.Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void NewProductShouldHaveId()
        {
            var user = new Product("", 0, 0, Guid.NewGuid());
            user.Id.Should().NotBeEmpty();
        }
    }
}
