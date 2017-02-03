webpackJsonp([0],{

/***/ 248:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

function __export(m) {
    for (var p in m) if (!exports.hasOwnProperty(p)) exports[p] = m[p];
}
__export(__webpack_require__(570));
__export(__webpack_require__(376));
__export(__webpack_require__(571));


/***/ }),

/***/ 286:
/***/ (function(module, exports, __webpack_require__) {

"use strict";
// The file for the current environment will overwrite this one during build
// Different environments can be found in config/environment.{dev|prod}.ts
// The build system defaults to the dev environment

exports.environment = {
    baseUrl: "",
    production: true
};


/***/ }),

/***/ 374:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var environment_1 = __webpack_require__(286);
var core_1 = __webpack_require__(1);
var http_1 = __webpack_require__(234);
var rxjs_1 = __webpack_require__(407);
var utilities_1 = __webpack_require__(248);
var ApiService = (function () {
    function ApiService(_http, _storage) {
        this._http = _http;
        this._storage = _storage;
    }
    ApiService.prototype.search = function (options) {
        return this._http
            .get(this._baseUrl + "/api/search/get?query=" + options.query)
            .map(function (data) { return data.json(); })
            .catch(function (err) {
            return rxjs_1.Observable.of(false);
        });
    };
    ApiService.prototype.getVideos = function () {
        return this._http
            .get(this._baseUrl + "/api/video/get")
            .map(function (data) { return data.json(); });
    };
    Object.defineProperty(ApiService.prototype, "_baseUrl", {
        get: function () { return environment_1.environment.baseUrl; },
        enumerable: true,
        configurable: true
    });
    ApiService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [(typeof (_a = typeof http_1.Http !== 'undefined' && http_1.Http) === 'function' && _a) || Object, (typeof (_b = typeof utilities_1.Storage !== 'undefined' && utilities_1.Storage) === 'function' && _b) || Object])
    ], ApiService);
    return ApiService;
    var _a, _b;
}());
exports.ApiService = ApiService;


/***/ }),

/***/ 375:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

function __export(m) {
    for (var p in m) if (!exports.hasOwnProperty(p)) exports[p] = m[p];
}
__export(__webpack_require__(374));
__export(__webpack_require__(569));


/***/ }),

/***/ 376:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = __webpack_require__(1);
exports.storageKey = "[Video Collection App] Storage";
var Storage = (function () {
    function Storage() {
        var _this = this;
        this._items = null;
        this.get = function (options) {
            var storageItem = null;
            for (var i = 0; i < _this.items.length; i++) {
                if (options.name === _this.items[i].name)
                    storageItem = _this.items[i].value;
            }
            return storageItem;
        };
        this.put = function (options) {
            var itemExists = false;
            _this.items.forEach(function (item) {
                if (options.name === item.name) {
                    itemExists = true;
                    item.value = options.value;
                }
            });
            if (!itemExists) {
                var items = _this.items;
                items.push({ name: options.name, value: options.value });
                _this.items = items;
                items = null;
            }
        };
        this.clear = function () {
            _this._items = [];
        };
        this._window = window;
        this._localStorage = localStorage;
        this._key = exports.storageKey;
        this.onPageHide = this.onPageHide.bind(this);
        this._window.addEventListener("pagehide", this.onPageHide);
    }
    Storage.prototype.onPageHide = function () {
        this._localStorage.setItem(this._key, JSON.stringify(this._items));
    };
    Object.defineProperty(Storage.prototype, "items", {
        get: function () {
            if (this._items === null) {
                var storageItems = this._localStorage.getItem(this._key);
                if (storageItems === "null") {
                    storageItems = null;
                }
                this._items = JSON.parse(storageItems || "[]");
            }
            return this._items;
        },
        set: function (value) {
            this._items = value;
        },
        enumerable: true,
        configurable: true
    });
    Storage = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [])
    ], Storage);
    return Storage;
}());
exports.Storage = Storage;


/***/ }),

/***/ 377:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

function __export(m) {
    for (var p in m) if (!exports.hasOwnProperty(p)) exports[p] = m[p];
}
__export(__webpack_require__(378));
__export(__webpack_require__(572));
__export(__webpack_require__(573));
__export(__webpack_require__(574));


/***/ }),

/***/ 378:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = __webpack_require__(1);
var utilities_1 = __webpack_require__(248);
var JwPlayerComponent = (function () {
    function JwPlayerComponent(_elementRef) {
        var _this = this;
        this._elementRef = _elementRef;
        this.uniqueId = utilities_1.guid();
        this.events = ['ready', 'play', 'pause', 'complete', 'seek', 'error', 'playlistItem', 'time', 'firstFrame'];
        this.playerEvent = new core_1.EventEmitter();
        this._playerInstance = null;
        this.handleEventsFor = function (player) {
            _this.events.forEach(function (type) {
                _this.playerInstance
                    .on(type, function (event) {
                    this.playerEvent.emit({
                        playerId: this.uniqueId,
                        event: event,
                        type: type,
                        playerInstance: this.playerInstance
                    });
                });
            });
        };
        this.seek = function (options) {
            _this.playerInstance.seek(options.duration);
        };
    }
    Object.defineProperty(JwPlayerComponent.prototype, "playerInstance", {
        get: function () {
            this._playerInstance = this._playerInstance || jwplayer(this._elementRef.nativeElement);
            return this._playerInstance;
        },
        enumerable: true,
        configurable: true
    });
    JwPlayerComponent.prototype.ngAfterViewInit = function () {
        this.playerInstance.setup({
            file: this.file,
            height: this.height,
            width: this.width
        });
        this.handleEventsFor(this.playerInstance);
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', String)
    ], JwPlayerComponent.prototype, "title", void 0);
    __decorate([
        core_1.Input(), 
        __metadata('design:type', String)
    ], JwPlayerComponent.prototype, "file", void 0);
    __decorate([
        core_1.Input(), 
        __metadata('design:type', String)
    ], JwPlayerComponent.prototype, "height", void 0);
    __decorate([
        core_1.Input(), 
        __metadata('design:type', String)
    ], JwPlayerComponent.prototype, "width", void 0);
    __decorate([
        core_1.Output(), 
        __metadata('design:type', (typeof (_a = typeof core_1.EventEmitter !== 'undefined' && core_1.EventEmitter) === 'function' && _a) || Object)
    ], JwPlayerComponent.prototype, "playerEvent", void 0);
    JwPlayerComponent = __decorate([
        core_1.Component({
            template: __webpack_require__(731),
            styles: [__webpack_require__(724)],
            selector: "jw-player-handler"
        }), 
        __metadata('design:paramtypes', [(typeof (_b = typeof core_1.ElementRef !== 'undefined' && core_1.ElementRef) === 'function' && _b) || Object])
    ], JwPlayerComponent);
    return JwPlayerComponent;
    var _a, _b;
}());
exports.JwPlayerComponent = JwPlayerComponent;


/***/ }),

/***/ 444:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = __webpack_require__(1);
var common_1 = __webpack_require__(40);
var platform_browser_1 = __webpack_require__(126);
var router_1 = __webpack_require__(127);
var http_1 = __webpack_require__(234);
var forms_1 = __webpack_require__(345);
__webpack_require__(566);
var app_component_1 = __webpack_require__(563);
var app_header_component_1 = __webpack_require__(561);
var app_routing_module_1 = __webpack_require__(562);
var utilities_1 = __webpack_require__(248);
var video_1 = __webpack_require__(377);
var shared_1 = __webpack_require__(375);
var declarables = [
    app_component_1.AppComponent,
    app_header_component_1.AppHeaderComponent
].concat(app_routing_module_1.routedComponents);
var AppModule = (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [
                utilities_1.UtilitiesModule,
                app_routing_module_1.RoutingModule,
                platform_browser_1.BrowserModule,
                http_1.HttpModule,
                common_1.CommonModule,
                forms_1.FormsModule,
                forms_1.ReactiveFormsModule,
                router_1.RouterModule,
                shared_1.SharedModule,
                video_1.VideoModule
            ],
            declarations: [declarables],
            exports: [declarables],
            bootstrap: [app_component_1.AppComponent]
        }), 
        __metadata('design:paramtypes', [])
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;


/***/ }),

/***/ 559:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = __webpack_require__(1);
var AboutPageComponent = (function () {
    function AboutPageComponent() {
    }
    AboutPageComponent.prototype.ngOnInit = function () {
    };
    AboutPageComponent = __decorate([
        core_1.Component({
            template: __webpack_require__(726),
            styles: [__webpack_require__(719)],
            selector: "about-page",
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        }), 
        __metadata('design:paramtypes', [])
    ], AboutPageComponent);
    return AboutPageComponent;
}());
exports.AboutPageComponent = AboutPageComponent;


/***/ }),

/***/ 560:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

function __export(m) {
    for (var p in m) if (!exports.hasOwnProperty(p)) exports[p] = m[p];
}
__export(__webpack_require__(559));


/***/ }),

/***/ 561:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = __webpack_require__(1);
var AppHeaderComponent = (function () {
    function AppHeaderComponent() {
    }
    AppHeaderComponent = __decorate([
        core_1.Component({
            template: __webpack_require__(727),
            styles: [__webpack_require__(720)],
            selector: "app-header",
            encapsulation: core_1.ViewEncapsulation.None
        }), 
        __metadata('design:paramtypes', [])
    ], AppHeaderComponent);
    return AppHeaderComponent;
}());
exports.AppHeaderComponent = AppHeaderComponent;


/***/ }),

/***/ 562:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var router_1 = __webpack_require__(127);
var landing_1 = __webpack_require__(564);
var about_1 = __webpack_require__(560);
var video_1 = __webpack_require__(377);
var search_1 = __webpack_require__(567);
exports.routes = [
    {
        path: '',
        component: landing_1.LandingPageComponent,
    },
    {
        path: 'about',
        component: about_1.AboutPageComponent
    },
    {
        path: 'search',
        component: search_1.SearchPageComponent
    },
    {
        path: 'video/:slug',
        component: video_1.VideoPageComponent
    }
];
exports.RoutingModule = router_1.RouterModule.forRoot(exports.routes.slice());
exports.routedComponents = [
    about_1.AboutPageComponent,
    landing_1.LandingPageComponent,
    video_1.VideoPageComponent,
    search_1.SearchPageComponent
];


/***/ }),

/***/ 563:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = __webpack_require__(1);
var router_1 = __webpack_require__(127);
var AppComponent = (function () {
    function AppComponent(_router) {
        this._router = _router;
    }
    AppComponent = __decorate([
        core_1.Component({
            template: __webpack_require__(728),
            styles: [__webpack_require__(721)],
            selector: "app",
            encapsulation: core_1.ViewEncapsulation.None
        }), 
        __metadata('design:paramtypes', [(typeof (_a = typeof router_1.Router !== 'undefined' && router_1.Router) === 'function' && _a) || Object])
    ], AppComponent);
    return AppComponent;
    var _a;
}());
exports.AppComponent = AppComponent;


/***/ }),

/***/ 564:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

function __export(m) {
    for (var p in m) if (!exports.hasOwnProperty(p)) exports[p] = m[p];
}
__export(__webpack_require__(565));


/***/ }),

/***/ 565:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = __webpack_require__(1);
var LandingPageComponent = (function () {
    function LandingPageComponent() {
    }
    LandingPageComponent = __decorate([
        core_1.Component({
            template: __webpack_require__(729),
            styles: [__webpack_require__(722)],
            selector: "landing-page"
        }), 
        __metadata('design:paramtypes', [])
    ], LandingPageComponent);
    return LandingPageComponent;
}());
exports.LandingPageComponent = LandingPageComponent;


/***/ }),

/***/ 566:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

__webpack_require__(411);
__webpack_require__(412);
__webpack_require__(413);
__webpack_require__(414);
__webpack_require__(415);
__webpack_require__(416);
__webpack_require__(410);
__webpack_require__(409);


/***/ }),

/***/ 567:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

function __export(m) {
    for (var p in m) if (!exports.hasOwnProperty(p)) exports[p] = m[p];
}
__export(__webpack_require__(568));


/***/ }),

/***/ 568:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = __webpack_require__(1);
var SearchPageComponent = (function () {
    function SearchPageComponent() {
    }
    SearchPageComponent.prototype.ngOnInit = function () {
    };
    SearchPageComponent = __decorate([
        core_1.Component({
            template: __webpack_require__(730),
            styles: [__webpack_require__(723)],
            selector: "search-page",
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        }), 
        __metadata('design:paramtypes', [])
    ], SearchPageComponent);
    return SearchPageComponent;
}());
exports.SearchPageComponent = SearchPageComponent;


/***/ }),

/***/ 569:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = __webpack_require__(1);
var common_1 = __webpack_require__(40);
var api_service_1 = __webpack_require__(374);
var providers = [api_service_1.ApiService];
var SharedModule = (function () {
    function SharedModule() {
    }
    SharedModule = __decorate([
        core_1.NgModule({
            imports: [common_1.CommonModule],
            providers: providers
        }), 
        __metadata('design:paramtypes', [])
    ], SharedModule);
    return SharedModule;
}());
exports.SharedModule = SharedModule;


/***/ }),

/***/ 570:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

function guid() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
            .toString(16)
            .substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
        s4() + '-' + s4() + s4() + s4();
}
exports.guid = guid;


/***/ }),

/***/ 571:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = __webpack_require__(1);
var common_1 = __webpack_require__(40);
var storage_1 = __webpack_require__(376);
var providers = [
    storage_1.Storage
];
var UtilitiesModule = (function () {
    function UtilitiesModule() {
    }
    UtilitiesModule = __decorate([
        core_1.NgModule({
            imports: [common_1.CommonModule],
            providers: providers
        }), 
        __metadata('design:paramtypes', [])
    ], UtilitiesModule);
    return UtilitiesModule;
}());
exports.UtilitiesModule = UtilitiesModule;


/***/ }),

/***/ 572:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = __webpack_require__(1);
var common_1 = __webpack_require__(40);
var router_1 = __webpack_require__(127);
var shared_1 = __webpack_require__(375);
var VideoPageComponent = (function () {
    function VideoPageComponent(_activatedRouteSnapshot, _apiService, _location) {
        this._activatedRouteSnapshot = _activatedRouteSnapshot;
        this._apiService = _apiService;
        this._location = _location;
        //public seek: number = 0;
        //public file: string = "https://www.youtube.com/watch?v=AslncyG8whg";
        //public height: string = "420px";
        //public width: string = "680px";
        //public onPlayerEvent($event: any) {
        //    switch ($event.type) {
        //        case "ready":
        //            break
        //    }
        //}
        this.currentVideo = {};
        this.videos = [];
    }
    VideoPageComponent.prototype.onNext = function () {
    };
    VideoPageComponent.prototype.onPrevious = function () {
    };
    VideoPageComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._apiService
            .getVideos()
            .subscribe(function (videos) {
            _this.videos = videos;
        });
    };
    VideoPageComponent = __decorate([
        core_1.Component({
            template: __webpack_require__(732),
            styles: [__webpack_require__(725)],
            selector: "video-page"
        }), 
        __metadata('design:paramtypes', [(typeof (_a = typeof router_1.ActivatedRouteSnapshot !== 'undefined' && router_1.ActivatedRouteSnapshot) === 'function' && _a) || Object, (typeof (_b = typeof shared_1.ApiService !== 'undefined' && shared_1.ApiService) === 'function' && _b) || Object, (typeof (_c = typeof common_1.Location !== 'undefined' && common_1.Location) === 'function' && _c) || Object])
    ], VideoPageComponent);
    return VideoPageComponent;
    var _a, _b, _c;
}());
exports.VideoPageComponent = VideoPageComponent;


/***/ }),

/***/ 573:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var Video = (function () {
    function Video() {
    }
    return Video;
}());
exports.Video = Video;


/***/ }),

/***/ 574:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = __webpack_require__(1);
var common_1 = __webpack_require__(40);
var jw_player_handler_component_1 = __webpack_require__(378);
var declarables = [jw_player_handler_component_1.JwPlayerComponent];
var providers = [];
var VideoModule = (function () {
    function VideoModule() {
    }
    VideoModule = __decorate([
        core_1.NgModule({
            imports: [common_1.CommonModule],
            exports: [declarables],
            declarations: [declarables],
            providers: providers
        }), 
        __metadata('design:paramtypes', [])
    ], VideoModule);
    return VideoModule;
}());
exports.VideoModule = VideoModule;


/***/ }),

/***/ 719:
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ 720:
/***/ (function(module, exports) {

module.exports = "app-header {\n  display: block;\n  margin: 0% 4%;\n  width: 100%; }\n  app-header h1, app-header a {\n    display: inline-block; }\n  app-header a {\n    margin-left: 4%;\n    cursor: pointer;\n    font-size: 1.25em; }\n"

/***/ }),

/***/ 721:
/***/ (function(module, exports) {

module.exports = "body, html {\n  margin: 0;\n  padding: 0; }\n\nbody {\n  font-size: 12px;\n  font-family: Montserrat;\n  background-color: #fff; }\n\na {\n  line-height: 2em; }\n\nh1 {\n  font-size: 3.5em;\n  line-height: 4em;\n  padding: 0;\n  margin: 0; }\n\nh2 {\n  font-size: 3em;\n  line-height: 3.5em;\n  padding: 0;\n  margin: 0; }\n"

/***/ }),

/***/ 722:
/***/ (function(module, exports) {

module.exports = ".landing-page {\n  text-align: center;\n  margin: 0% 4%; }\n  .landing-page h2 {\n    font-size: 6em;\n    letter-spacing: 3px; }\n"

/***/ }),

/***/ 723:
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ 724:
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ 725:
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ 726:
/***/ (function(module, exports) {

module.exports = "<div class=\"about-page\">\r\n    <p>Video on demand app built with Angular, Web API 2, MediatR (CQRS), TypeScript 2x and Webpack 2.x</p>\r\n</div>\r\n"

/***/ }),

/***/ 727:
/***/ (function(module, exports) {

module.exports = "<h1>Video Collection</h1>"

/***/ }),

/***/ 728:
/***/ (function(module, exports) {

module.exports = "<div class=\"app\">\r\n    <app-header></app-header>\r\n    <div>\r\n        <router-outlet></router-outlet>\r\n    </div>\r\n</div>\r\n"

/***/ }),

/***/ 729:
/***/ (function(module, exports) {

module.exports = "<div class=\"landing-page\">\r\n    <h2>Video Collection</h2>\r\n</div>\r\n"

/***/ }),

/***/ 730:
/***/ (function(module, exports) {

module.exports = "<h2>Search</h2>"

/***/ }),

/***/ 731:
/***/ (function(module, exports) {

module.exports = "<div class=\"jw-player-handler\">\r\n\r\n</div>\r\n"

/***/ }),

/***/ 732:
/***/ (function(module, exports) {

module.exports = "<div class=\"video-page\">\r\n    <!--<jw-player-handler [file]=\"file\"\r\n                       [height]=\"height\"\r\n                       [width]=\"width\"\r\n                       (playerEvent)=\"onPlayerEvent($event)\">\r\n    </jw-player-handler>-->\r\n</div>\r\n"

/***/ }),

/***/ 993:
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var environment_1 = __webpack_require__(286);
var core_1 = __webpack_require__(1);
var app_module_1 = __webpack_require__(444);
var platform_browser_dynamic_1 = __webpack_require__(285);
if (environment_1.environment.production) {
    core_1.enableProdMode();
}
platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(app_module_1.AppModule)
    .catch(function (err) { return console.error(err); });


/***/ })

},[993]);
//# sourceMappingURL=app.js.map