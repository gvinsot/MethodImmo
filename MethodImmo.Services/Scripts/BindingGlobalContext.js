///<reference path="StringTools.ts" />
///<reference path="libs/jquery.d.ts" />
///<reference path="EventHandler.ts" />
///<reference path="Interfaces.ts" />
///<reference path="FileTools.ts" />
var SS;
(function (SS) {
    var BindingGlobalContext = (function () {
        function BindingGlobalContext() {
            this.BindingDictionary = new Object();
            this.CurrentBindingId = 0;
        }
        BindingGlobalContext.prototype.CreateBinding = function (bindedObject, path, node) {
            if (node["data-binding-ids"] == undefined) {
                node["data-binding-ids"] = [];
            }
            this.CurrentBindingId++;
            var bindingsIds = node["data-binding-ids"];
            var length = bindingsIds.length;
            var bindingId = this.CurrentBindingId;
            bindingsIds[length] = bindingId;
            var binding = new SS.Binding(path, node, bindedObject);
            this.BindingDictionary[bindingId] = binding;
            return binding;
        };
        BindingGlobalContext.prototype.DisposeNodeBindings = function (node) {
            if (node.attributes != undefined && node.attributes != null) {
                //delete node["data-binding-value"];
                delete node["data-context-value"];
                delete node["data-template-value"];
                delete node["data-source-value"];
                if (node["data-binding-ids"] != undefined) {
                    var bindingsIds = node["data-binding-ids"];
                    for (var bindingId in bindingsIds) {
                        var binding = this.BindingDictionary[bindingId];
                        if (binding.Node != null) {
                            binding.Dispose();
                            delete this.BindingDictionary[bindingId];
                            binding = null;
                        }
                    }
                    delete node["data-binding-ids"];
                }
            }
        };
        BindingGlobalContext.prototype.GarbageCollectBindings = function () {
            for (var key in this.BindingDictionary) {
                // skip loop if the property is from prototype
                if (!this.BindingDictionary.hasOwnProperty(key))
                    continue;
                var binding = this.BindingDictionary[key];
                if (binding.Node != null && !this.IsAttachedToDOM(binding.Node)) {
                    binding.Dispose();
                    delete this.BindingDictionary[key];
                }
                binding = null;
            }
        };
        BindingGlobalContext.prototype.IsAttachedToDOM = function (ref) {
            return ref.parentElement == undefined;
        };
        return BindingGlobalContext;
    }());
    SS.BindingGlobalContext = BindingGlobalContext;
})(SS || (SS = {}));
//# sourceMappingURL=BindingGlobalContext.js.map