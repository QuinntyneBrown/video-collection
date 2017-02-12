import { Component, Input, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { DigitalAssetService } from "./digital-asset.service";
import { DigitalAsset } from "./digital-asset.model";

@Component({
    template: require("./digital-asset-edit-page.component.html"),
    styles: [require("./digital-asset-edit-page.component.scss")],
    selector: "digital-asset-edit-page"
})
export class DigitalAssetEditPageComponent implements OnInit { 
    constructor(
        private _digitalAssetService: DigitalAssetService,
        private _router: Router,
        private _activatedRoute: ActivatedRoute
    ) { }

    ngOnInit() {
        this._digitalAssetService.getById({ id: this._digitalAssetId })
            .subscribe((results:any) => {
                this.digitalAsset = results;
            });
    }

    public onSave() {
        this._digitalAssetService.addOrUpdate({ data: this.digitalAsset })
            .subscribe(() => {
                this._router.navigate(['digital-asset','list']);
            });        
    }

    public onRemove() {
        this._digitalAssetService.remove({ id: this.digitalAsset.id })
            .subscribe(() => {
                this._router.navigate(['digital-asset', 'list']);
            });
    }

    private digitalAsset: DigitalAsset = <DigitalAsset>{};
     
    private get _digitalAssetId() { return this._activatedRoute.snapshot.params["id"]; }
}
