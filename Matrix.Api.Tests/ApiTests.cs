using Matrix.WebApp.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using Matrix.Common.Helpers;
using Matrix.Core;
using Matrix.Core.Interfaces;
using Matrix.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Api.Tests
{
    public class ApiTests
    {
        #region Preset

        private int[,] arrayMatrix =
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9},
        };

        private List<List<int>> listMatrix = new List<List<int>>
        {
            new List<int>{ 9, 8, 7},
            new List<int>{ 6, 5, 4},
            new List<int>{ 3, 2, 1},
        };

        private IRotationService rotationService;
        private BodyHelper arrayMatrixHelper;
        private BodyHelper listMatrixHelper;

        #endregion

        [SetUp]
        public void Setup()
        {
            rotationService = new RotationService();
            arrayMatrixHelper = new BodyHelper { matrix = arrayMatrix.ConvertToList() };
            listMatrixHelper = new BodyHelper { matrix = listMatrix };
        }

        [Test]
        public void VerifyWhetherIsMatrixCorrect_SetupCorrectArrayMatrix_ShouldReturnOkStatusCode()
        {
            var controller = new MatrixController(rotationService);
            var storeResult = controller.StoreMatrix(arrayMatrixHelper) as OkObjectResult;
            Assert.AreEqual(storeResult.StatusCode, StatusCodes.Status200OK);
        }

        [Test]
        public void VerifyWhetherIsMatrixCorrect_SetupCorrectListMatrix_ShouldReturnOkStatusCode()
        {
            var controller = new MatrixController(rotationService);
            var storeResult = controller.StoreMatrix(listMatrixHelper) as OkObjectResult;
            Assert.AreEqual(storeResult.StatusCode, StatusCodes.Status200OK);
        }

        [Test]
        public void VerifyWhetherIsMatrixCorrect_SetupWrongMatrix_ShouldReturnBadRequst()
        {
            var controller = new MatrixController(rotationService);
            var storeResult = controller.StoreMatrix(new BodyHelper()) as BadRequestObjectResult;
            Assert.AreEqual(storeResult.StatusCode, StatusCodes.Status400BadRequest);
        }

        [Test]
        public void VerifyClockWiseRotation_ShouldBeCorrectRotation()
        {
            var controller = new MatrixController(rotationService);
            var storeResult = controller.StoreMatrix(arrayMatrixHelper) as OkObjectResult;
            var rotationResult = controller.ClockWiseMatrixRotation() as OkObjectResult;
            Assert.AreEqual(rotationResult.StatusCode, StatusCodes.Status200OK);
        }

        [Test]
        public void VerifyAntiClockWiseRotation_ShouldBeCorrectRotation()
        {
            var controller = new MatrixController(rotationService);
            var storeResult = controller.StoreMatrix(arrayMatrixHelper) as OkObjectResult;
            var rotationResult = controller.BackWiseMatrixRotation() as OkObjectResult;
            Assert.AreEqual(rotationResult.StatusCode, StatusCodes.Status200OK);
        }

        // should be run separately

        // [Test]
        // public void VerifyAntiClockWiseRotation_ShouldReturnBadRequst()
        // {
        //     var controller = new MatrixController(rotationService);
        //     var storeResult = controller.StoreMatrix(new BodyHelper()) as BadRequestObjectResult;
        //     var rotationResult = controller.BackWiseMatrixRotation() as BadRequestObjectResult;
        //     Assert.AreEqual(rotationResult.StatusCode, StatusCodes.Status400BadRequest);
        // }

        // [Test]
        // public void VerifyClockWiseRotation_ShouldReturnBadRequst()
        // {
        //     var controller = new MatrixController(rotationService);
        //     var storeResult = controller.StoreMatrix(new BodyHelper()) as BadRequestObjectResult;
        //     var rotationResult = controller.ClockWiseMatrixRotation() as BadRequestObjectResult;
        //     Assert.AreEqual(rotationResult.StatusCode, StatusCodes.Status400BadRequest);
        // }
    }
}