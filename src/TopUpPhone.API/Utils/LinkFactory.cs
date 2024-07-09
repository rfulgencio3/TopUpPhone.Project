using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using TopUpPhone.Application.Common;
using TopUpPhone.Application.DTOs;

namespace TopUpPhone.API.Utils
{
    public class LinkFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlHelperFactory _urlHelperFactory;

        public LinkFactory(IHttpContextAccessor httpContextAccessor, IUrlHelperFactory urlHelperFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _urlHelperFactory = urlHelperFactory;
        }

        private IUrlHelper CreateUrlHelper()
        {
            var actionContext = new ActionContext(
                _httpContextAccessor.HttpContext,
                _httpContextAccessor.HttpContext.GetRouteData(),
                new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()
            );

            return _urlHelperFactory.GetUrlHelper(actionContext);
        }

        public void AddLinks(UserDTO user)
        {
            var urlHelper = CreateUrlHelper();
            user.Links.Add(new LinkHelper(urlHelper.Link("GetUserById", new { id = user.Id }), "self", "GET"));
            user.Links.Add(new LinkHelper(urlHelper.Link("GetBeneficiaryByUserId", new { id = user.Id }), "user-beneficiaries", "GET"));
        }

        public void AddLinks(BeneficiaryDTO beneficiary)
        {
            var urlHelper = CreateUrlHelper();
            beneficiary.Links.Add(new LinkHelper(urlHelper.Link("GetBeneficiaryById", new { id = beneficiary.Id }), "self", "GET"));
        }

        public void AddLinks(TopUpItemDTO topUpItem)
        {
            var urlHelper = CreateUrlHelper();
            topUpItem.Links.Add(new LinkHelper(urlHelper.Link("GetTopUpItemById", new { id = topUpItem.Id }), "self", "GET"));
            topUpItem.Links.Add(new LinkHelper(urlHelper.Link("GetAllTopUpItems", null), "all-topupitems", "GET"));
        }
    }
}
