import { Component, ChangeDetectionStrategy, Input, OnInit, ElementRef } from "@angular/core";
import { ApiService } from "../shared";
import { Router } from "@angular/router";
import { Observable } from "rxjs";

@Component({
    template: require("./search-page.component.html"),
    styles: [require("./search-page.component.scss")],
    selector: "search-page"
})
export class SearchPageComponent implements OnInit { 
    constructor(
        private _apiService: ApiService,
        private _elementRef: ElementRef,
        private _router: Router
    ) {

    }

    ngOnInit = () => {
        let inputChanged$ = Observable
            .fromEvent(this.$input, 'keyup')
            .map(function (e: any) {
                return e.target.value;
            })
            .filter(function (text) {
                return text.length > 2;
            })
            .distinctUntilChanged();

        var searcher = inputChanged$.switchMap((data) => Observable.from(data));


    }

    get $input(): HTMLElement { return (<HTMLElement>this._elementRef.nativeElement).querySelector('#textInput') as HTMLElement; }

    public results: Array<any>;
}
