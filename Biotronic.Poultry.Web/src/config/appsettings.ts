import * as environment from '~/../../config/environment.json';

export interface IEndpointList {
    poultry: string;
}

export class AppSettings {
    public static readonly endpoints: IEndpointList = environment.endpoints;
}
