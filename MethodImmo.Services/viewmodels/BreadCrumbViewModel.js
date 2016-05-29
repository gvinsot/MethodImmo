var MI;
(function (MI) {
    var BreadCrumbViewModel = (function () {
        function BreadCrumbViewModel() {
            this.Selected = null;
            this.PropertyChanged = new SS.EventHandler();
            this.PropertyChanged.Attach(function (ctx, args) {
                SS.ApplyBindings('breadcrumb');
                SS.SetTemplate('view', args.DataTemplateUri, args.BreadDataContext);
            }, null);
            this.Values = new Array();
        }
        return BreadCrumbViewModel;
    }());
    MI.BreadCrumbViewModel = BreadCrumbViewModel;
    var BreadCrumbItemViewModel = (function () {
        function BreadCrumbItemViewModel(dataTemplateUri, breadCrumbContext) {
            this.OnClick = function () {
                SS.SetTemplate('view', this.DataTemplateUri, this.BreadDataContext);
                var vm = SS.GetDataContext('breadcrumb');
                vm.Values = vm.Values.slice(0, vm.Values.lastIndexOf(this) + 1);
                SS.ApplyBindings('breadcrumb');
            };
            this.DataTemplateUri = dataTemplateUri;
            this.BreadDataContext = breadCrumbContext;
        }
        return BreadCrumbItemViewModel;
    }());
    MI.BreadCrumbItemViewModel = BreadCrumbItemViewModel;
})(MI || (MI = {}));
function AddBreadCrumbItem(templateUrl, context) {
    SS.BindingTools.EvaluateDataContext(context, function (ctxt, dataContextObject) {
        var item = new MI.BreadCrumbItemViewModel(templateUrl, dataContextObject);
        var breadCrumbVM = SS.GetDataContext('breadcrumb');
        breadCrumbVM.Values[breadCrumbVM.Values.length] = item;
        breadCrumbVM.PropertyChanged.FireEvent(item);
    });
}
function OpenImmeuble(element) {
    var context = SS.GetDataContext(element);
    var viewModel = new MI.BreadCrumbViewModel();
    var item = new MI.BreadCrumbItemViewModel('views/immeuble/edit.html', context);
    viewModel.Values[0] = item;
    SS.SetTemplate('page-content-wrapper', 'views/Immeuble/BreadAndView.html', viewModel);
}
//# sourceMappingURL=BreadCrumbViewModel.js.map