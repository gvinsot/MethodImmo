
module MI
{
    export class BreadCrumbViewModel {

        constructor() {
            this.PropertyChanged = new SS.EventHandler();
            this.PropertyChanged.Attach(function (ctx, args) {
                SS.ApplyBindings('breadcrumb');
                SS.SetTemplate('view', args.DataTemplateUri, args.BreadDataContext);
            }, null);
            this.Values = new Array<BreadCrumbItemViewModel>();
        }
        public Selected: BreadCrumbItemViewModel = null;
        public Values: BreadCrumbItemViewModel[];
        public PropertyChanged: SS.EventHandler;
    }

    export class BreadCrumbItemViewModel {
        public DataTemplateUri: string;
        public BreadDataContext: any;
        constructor(dataTemplateUri: string, breadCrumbContext: any) {
            this.DataTemplateUri = dataTemplateUri;
            this.BreadDataContext = breadCrumbContext;
        }
        public OnClick = function () {
            SS.SetTemplate('view', this.DataTemplateUri, this.BreadDataContext);
            var vm: BreadCrumbViewModel = SS.GetDataContext('breadcrumb');
            vm.Values = vm.Values.slice(0, vm.Values.lastIndexOf(this)+1);  
            SS.ApplyBindings('breadcrumb');          
        };
    }
}

function AddBreadCrumbItem(templateUrl: string, context: any) {
    SS.BindingTools.EvaluateDataContext(context, (ctxt, dataContextObject) => {
        var item = new MI.BreadCrumbItemViewModel(templateUrl, dataContextObject);
        var breadCrumbVM = SS.GetDataContext('breadcrumb');
        breadCrumbVM.Values[breadCrumbVM.Values.length] = item;
        breadCrumbVM.PropertyChanged.FireEvent(item);
    });
}

function OpenImmeuble(element: HTMLElement) {
    var context = SS.GetDataContext(element);
    var viewModel = new MI.BreadCrumbViewModel();
    var item = new MI.BreadCrumbItemViewModel('views/immeuble/edit.html', context);
    viewModel.Values[0] = item;
    SS.SetTemplate('page-content-wrapper', 'views/Immeuble/BreadAndView.html', viewModel);    
}
