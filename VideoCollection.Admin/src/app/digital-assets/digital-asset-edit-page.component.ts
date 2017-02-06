import { Component, Input, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
    template: require("./digital-asset-edit-page.component.html"),
    styles: [require("./digital-asset-edit-page.component.scss")],
    selector: "digital-asset-edit-page"
})
export class DigitalAssetEditPageComponent { 
    constructor(
        private _router: Router,
        private _activatedRoute: ActivatedRoute
    ) { }

    private get _digitalAssetId() { return this._activatedRoute.snapshot.params["id"]; }
}
