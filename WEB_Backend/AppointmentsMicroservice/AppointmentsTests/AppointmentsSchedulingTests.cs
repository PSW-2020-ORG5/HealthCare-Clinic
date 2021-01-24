using Appointments;
using Appointments.Model;
using Appointments.Repository;
using Appointments.Services;
using LoginMicroservice.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace AppointmentsTests
{
    public class AppointmentsSchedulingTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly CheckupRepository repository;
        private readonly WebApplicationFactory<Startup> factory;

        public AppointmentsSchedulingTests(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
            var dbContext = new AppointmentsDbContext();
            this.repository = new CheckupRepository(dbContext);
        }

        private DoctorCheckupDTO DctorCheckupData()
        {
            var dto = new DoctorCheckupDTO();
            dto.DoctorId = 8;
            dto.CheckupStartTime = new DateTime(2021, 4, 6, 0, 0, 0);
            dto.FromDate = new DateTime(2021, 4, 1, 0, 0, 0);
            dto.ToDate = new DateTime(2021, 4, 12, 1, 1, 1);
            dto.FromHour = new DateTime(2021, 4, 1, 14, 0, 0);
            dto.ToHour = new DateTime(2021, 4, 12, 21, 0, 0);
            return dto;
        }

        private Checkup CheckupForCanceling()
        {
            var checkup = new Checkup();
            checkup.TermId = 101;
            checkup.StartTime = new DateTime(2021, 5, 1, 0, 0, 0);
            checkup.EndTime = new DateTime(2021, 5, 1, 0, 0, 0);
            checkup.MedicalRecordId = 2;
            repository.Save(checkup);
            return checkup;
        }

        private DoctorCheckupDTO DoctorCheckupDataForCanceling() {
            var dto = new DoctorCheckupDTO();
            dto.DoctorId = 8;
            dto.FromDate = new DateTime(2021, 5, 1, 0, 0, 0);
            dto.ToDate = new DateTime(2021, 5, 12, 0, 0, 0);
            dto.FromHour = new DateTime(2021, 5, 1, 14, 0, 0);
            dto.ToHour = new DateTime(2021, 5, 12, 21, 0, 0);
            dto.CheckupStartTime = new DateTime(2021, 6, 15, 7, 0, 0);
            dto.CheckupEndTime = new DateTime(2021, 6, 15, 7, 30, 0);
            return dto;
        }

        [Fact]
        public async void Avaliable_appointments() 
        {
            var client = factory.CreateClient();
            var dto = DctorCheckupData();
            var response = await client.PostAsync("api/checkups/freeCheckups", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));
            Assert.Equal(14, JsonConvert.DeserializeObject<List<Checkup>>(response.Content.ReadAsStringAsync().Result).Count);
        }

        [Fact]
        public async void Schedule_appointment()
        {
            var client = factory.CreateClient();
            var dto = DctorCheckupData(); 
            var response = await client.PostAsync("api/checkups/schedule", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));
            Assert.Equal(true, JsonConvert.DeserializeObject<bool>(response.Content.ReadAsStringAsync().Result));
        }

        [Fact]
        public async void Cancel_appointment()
        {
            var checkup = CheckupForCanceling();
            var client = factory.CreateClient();
            var response = await client.DeleteAsync("api/checkups/cancel/101");
            Assert.Equal("true", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async void Cancel_appointment_not_exist()
        {
            var client = factory.CreateClient();
            var response = await client.DeleteAsync("api/checkups/cancel/100");
            Assert.Equal("false", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async void Schedule_appointment_doctor_doesnt_work()
        {
            var client = factory.CreateClient();
            var dto = DoctorCheckupDataForCanceling();
            var response = await client.PostAsync("api/checkups/schedule", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));
            Assert.Equal(false, JsonConvert.DeserializeObject<bool>(response.Content.ReadAsStringAsync().Result));
        }
    }
}
