import { autoinject } from 'aurelia-property-injection';
import { Config, Rest } from 'aurelia-api';

@autoinject
export class BaseService {
    @autoinject
    protected config: Config;

    protected constructor(private endpointName: string) {
    }

    protected getEndpoint(): Rest {
        return this.config.getEndpoint(this.endpointName);
    }

    private request(method: string, url: string, body: any) {
        let endpoint = this.getEndpoint();
        return endpoint.request(method, url, JSON.stringify(body));
    }

    protected put(url: string, body: any) {
        return this.request("put", url, body);
    }

    protected post(url: string, body: any) {
        return this.request("post", url, body);
    }

    protected get(url: string, body: any) {
        return this.request("get", url, body);
    }
}
