import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs";
import { OAuthHelper } from "../utilities";

@Injectable()
export class DigitalAssetService {
    constructor(private _http: Http, private _oauthHelper: OAuthHelper) { }

    public upload(options: { data: FormData}) {
        return this._http
            .post(`${this._baseUrl}/api/digitalasset/upload`, options.data, { headers: this._oauthHelper.getOAuthHeaders() })
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
