﻿// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using ZumoE2EServerApp.DataObjects;
using ZumoE2EServerApp.Models;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace ZumoE2EServerApp.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class OfflineReadyNoVersionAuthenticatedController : TableController<OfflineReady>
    {
        private SDKClientTestContext context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new SDKClientTestContext();
            this.DomainManager = new EntityDomainManager<OfflineReady>(context, Request, Services);
        }

        [Queryable(MaxTop = 1000)]
        public IQueryable<OfflineReady> GetAll()
        {
            return Query();
        }

        public SingleResult<OfflineReady> Get(string id)
        {
            return Lookup(id);
        }

        public Task<OfflineReady> Post(OfflineReady item)
        {
            return InsertAsync(item);
        }

        public Task<OfflineReady> Patch(string id, Delta<OfflineReady> item)
        {
            return UpdateAsync(id, item);
        }

        public Task Delete(string id)
        {
            return DeleteAsync(id);
        }
    }
}
