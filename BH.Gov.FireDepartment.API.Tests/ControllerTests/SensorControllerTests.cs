using BH.Gov.FireDepartment.API.Contracts;
using BH.Gov.FireDepartment.API.Controllers;
using BH.Gov.FireDepartment.API.Model;
using BH.Gov.FireDepartment.API.Tests.Fakes;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BH.Gov.FireDepartment.API.Tests.ControllerTests
{
    public class SensorControllerTests
    {
        private Mock<ISensorService> mockSensorService { get; set; }
        private SensorsController sensorsController { get; set; }
        private SensorControllerTestData sensorControllerTestData { get; set; }

        public SensorControllerTests()
        {
            mockSensorService = new Mock<ISensorService>();
            sensorsController = new SensorsController(mockSensorService.Object);
            sensorControllerTestData = new SensorControllerTestData();
        }


        [Fact]
        public async void GetAllSensors_Returns_Ok()
        {
            //Arrange
            mockSensorService
                .Setup(x => x.GetSensors())
                .Returns(Task.FromResult(sensorControllerTestData.GetAllSensorsPopulated()));

            //Act
            var response = await sensorsController.GetAllSensors();
            var data = (response as OkObjectResult).Value;
            var sensors = (List<Sensor>)data;

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            Assert.NotNull(sensors);
            Assert.NotEmpty(sensors);
            mockSensorService.Verify(x => x.GetSensors(), Times.Once);
        }

        [Fact]
        public async void GetAllSensors_Returns_NoContent()
        {
            //Arrange
            mockSensorService
                .Setup(x => x.GetSensors())
                .Returns(Task.FromResult(sensorControllerTestData.GetAllSensorsEmpty()));

            //Act
            var response = await sensorsController.GetAllSensors();

            //Assert
            response.Should().BeOfType<NoContentResult>();
            mockSensorService.Verify(x => x.GetSensors(), Times.Once);
        }

        [Fact]
        public async void GetActiveSensors_Returns_Ok()
        {
            //Arrange
            mockSensorService
                .Setup(x => x.GetSensors())
                .Returns(Task.FromResult(sensorControllerTestData.GetActiveSensorsPopulated()));


            //Act
            var response = await sensorsController.GetActiveSensors();
            var data = (response as OkObjectResult).Value;
            var sensors = (List<Sensor>)data;

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            mockSensorService.Verify(x => x.GetSensors(), Times.Once);
            Assert.NotNull(sensors);
            Assert.NotEmpty(sensors);
            sensors.Should().HaveCount(1);
        }

        [Fact]
        public async void GetActiveSensors_Returns_NoContent()
        {
            //Arrange
            mockSensorService
                .Setup(x => x.GetSensors())
                .Returns(Task.FromResult(sensorControllerTestData.GetAllSensorsEmpty()));

            //Act
            var response = await sensorsController.GetActiveSensors();

            //Assert
            response.Should().BeOfType<NoContentResult>();
            mockSensorService.Verify(x => x.GetSensors(), Times.Once);
        }

        [Fact]
        public async void GetSensorById_Returns_Ok()
        {
            //Arrange
            var sensorId = "SAFBIH_1234ST01";
            mockSensorService
                .Setup(x => x.GetSensors())
                .Returns(Task.FromResult(sensorControllerTestData.GetAllSensorsPopulated()));


            //Act
            var response = await sensorsController.GetSensorById(sensorId);
            var data = (response as OkObjectResult).Value;
            var sensor = (Sensor)data;

            //Assert
            response.Should().BeOfType<OkObjectResult>();

            sensor.Should().NotBeNull();
            mockSensorService.Verify(x => x.GetSensors(), Times.Once);

        }

        [Fact]
        public async void GetSensorById_Returns_NoContent()
        {
            //Arrange
            var sensorId = "KOFBIH_1234LLS";

            mockSensorService
                .Setup(x => x.GetSensors())
                .Returns(Task.FromResult(sensorControllerTestData.GetAllSensorsPopulated()));


            //Act
            var response = await sensorsController.GetSensorById(sensorId);

            //Assert
            response.Should().BeOfType<NoContentResult>();
            mockSensorService.Verify(x => x.GetSensors(), Times.Once);
        }

        [Fact]
        public async void AddSensor_InvalidRequest_Returns_BadRequest()
        {
            //Arrange
            var sensorRequest = sensorControllerTestData.GetInvalidSensorRequest();

            //Act
            var response = await sensorsController.AddSensor(sensorRequest);
            var message = (response as BadRequestObjectResult).Value;

            //Assert
            response.Should().BeOfType<BadRequestObjectResult>();
            Assert.Equal("Invalid request", message);

        }

        [Fact]
        public async void AddSensor_Returns_Ok()
        {
            //Arrange
            var sensorRequest = sensorControllerTestData.GetValidSensorRequest();

            //Act
            var response = await sensorsController.AddSensor(sensorRequest);
            var message = (response as OkObjectResult).Value;

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            Assert.Equal("Ok", message);
        }
    }
}
