import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs";
import { OAuthHelper } from "../utilities";
import { ExceptionService } from "../core";
import { ConfigurationService } from "../configuration";
import { DigitalAsset } from "./digital-asset.model";

@Injectable()
export class DigitalAssetService {
    constructor(
        private _configurationService: ConfigurationService,
        private _http: Http,
        private _oauthHelper: OAuthHelper) { }

    public upload(options: { data: FormData}) {
        return this._http
            .post(`${this._baseUrl}/api/digitalasset/upload`, options.data, { headers: this._oauthHelper.getOAuthHeaders() })
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public addOrUpdate(options: { data: DigitalAsset }) {
        return this._http
            .post(`${this._baseUrl}/api/digitalasset/addorupdate`, options.data, { headers: this._oauthHelper.getOAuthHeaders() })
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: any }) {
        return this._http
            .get(`${this._baseUrl}/api/digitalasset/getbyid?id${options.id}`, { headers: this._oauthHelper.getOAuthHeaders() })
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: any }) {
        return this._http
            .delete(`${this._baseUrl}/api/digitalasset/remove?id${options.id}`, { headers: this._oauthHelper.getOAuthHeaders() })
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${this._baseUrl}/api/digitalasset/get`, { headers: this._oauthHelper.getOAuthHeaders() })
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get _baseUrl() { return ""; }

}
