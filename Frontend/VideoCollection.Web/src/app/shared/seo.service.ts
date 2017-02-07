import { Injectable } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { getDOM } from '@angular/platform-browser/src/dom/dom_adapter';

@Injectable()
export class SeoService {
    private _baseTitle: string;
    private _headElement: HTMLElement;
    private _metaDescription: HTMLElement;
    private _robots: HTMLElement;
    private _documentObjectModel: any;

    constructor(private _title: Title) {
        this._documentObjectModel = getDOM();
        this._headElement = this._documentObjectModel.query('head');
        this._metaDescription = this.getOrCreateMetaElement('description');
        this._robots = this.getOrCreateMetaElement('robots');
    }

    public getTitle(): string {
        return this._title.getTitle();
    }

    public setTitle(newTitle: string, baseTitle = false) {
        this._title.setTitle(newTitle);
    }

    public setMetaRobots(robots: string) {
        this._robots.setAttribute('content', robots);
    }

    private getOrCreateMetaElement(name: string): HTMLElement {
        let el: HTMLElement;
        el = this._documentObjectModel.query('meta[name=' + name + ']');
        if (el === null) {
            el = this._documentObjectModel.createElement('meta');
            el.setAttribute('name', name);
            this._headElement.appendChild(el);
        }
        return el;
    }

}