private readonly Mock<IAuditAccessor> _AuditManagerMock = new(MockBehavior.Strict);

        [TestMethod]
        public async Task CreateAuditSuccess()
        {
            // ARRANGE
            _AuditManagerMock.Setup(a => a.CreateAudit(It.IsAny<Audit>())).Returns(Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)));
            var manager = new AuditManager(_AuditManagerMock.Object, CreateLogger<AuditManager>(), GetContext());
            var auditFaker = new AuditFaker().Generate();

            // ACT
            await manager.CreateAudit(auditFaker);

            // ASSERT
            // Essentially make sure the call doesn't give an RmsException
            auditFaker.Should().NotBeNull();
        }
