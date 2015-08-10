
namespace Plugin.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Sample controller
    /// </summary>
    public class PluginController : Controller
    {
        /// <summary>
        /// Sample repo
        /// </summary>
        private readonly IMessageRepository _messageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginController"/> class. 
        /// </summary>
        /// <param name="messageRepository">
        /// Injected repo
        /// </param>
        public PluginController(IMessageRepository messageRepository)
        {
            this._messageRepository = messageRepository;
        }
        #region Public Methods

        /// <summary>
        /// Index action
        /// </summary>
        /// <returns>A view</returns>
        public ActionResult Index()
        {
            this.ViewBag.Message = this._messageRepository.Message;
            return this.View();
        }

        #endregion Public Methods
    }
}