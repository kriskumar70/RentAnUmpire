"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var UmpireDetailsComponent = /** @class */ (function () {
    function UmpireDetailsComponent() {
        this.settings = {
            columns: {
                id: {
                    title: 'Id',
                    filter: true,
                },
                firstname: {
                    title: 'Firstname',
                    filter: true,
                },
                lastname: {
                    title: 'Lastname',
                    filter: true,
                }
            },
            pager: {
                display: true,
                perPage: 10
            },
            actions: {
                columnTitle: 'Action',
                add: false,
                edit: false,
                delete: false,
                position: 'left'
            },
            attr: {
                class: 'table table-striped table-bordered table-hover'
            },
            defaultStyle: false
        };
        this.data = [
            {
                id: 1,
                firstname: "Kaushik",
                lastname: "dhameliya"
            },
            {
                id: 2,
                firstname: "Manish",
                lastname: "Vadher"
            },
            {
                id: 3,
                firstname: "Sanket",
                lastname: "Vagadiya"
            },
            {
                id: 4,
                firstname: "Vaibhav",
                lastname: "Bavishi"
            },
            {
                id: 5,
                firstname: "Tushar",
                lastname: "Kyada"
            }
        ];
    }
    UmpireDetailsComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'umpire-details',
            templateUrl: 'umpire-details.component.html'
        })
    ], UmpireDetailsComponent);
    return UmpireDetailsComponent;
}());
exports.UmpireDetailsComponent = UmpireDetailsComponent;
//# sourceMappingURL=umpire-details.component.js.map