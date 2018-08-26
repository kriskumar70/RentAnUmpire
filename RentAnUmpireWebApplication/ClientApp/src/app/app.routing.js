"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var home_1 = require("./home");
var login_1 = require("./login");
var register_1 = require("./register");
var _guards_1 = require("./_guards");
var umpire_details_1 = require("./umpire-details");
var appRoutes = [
    { path: '', component: home_1.HomeComponent, canActivate: [_guards_1.AuthGuard] },
    { path: 'login', component: login_1.LoginComponent },
    { path: 'register', component: register_1.RegisterComponent },
    { path: 'umpire-details', component: umpire_details_1.UmpireDetailsComponent },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map