import "date-fns"
import { IFarm, IMessage } from "model/farm";
import { BaseService } from "./baseservice";

export class PoultryService extends BaseService {
    public constructor() {
        super("poultry")
    }

    public signIn(token: string) {
        this.post("/auth/signin", token);
    }

    public signOut(token: string) {
        this.post("/auth/signout", token);
    }

    public getFarms(): IMessage<IFarm[]> {
        return {
            value: [{
                name: 'Test farm 1',
                address: 'foo',
                zipcode: '3158',
                houses: [{
                    name: 'Test house 1',
                    address: 'foo',
                    zipcode: '',
                    silos: [],
                    broods: [{
                        broodNumber: 1,
                        comments: [],
                        days: [],
                        deliveries: [],
                        disinfections: [],
                        feeds: [],
                        treatments: []
                    },{
                        broodNumber: 2,
                        comments: [],
                        days: [],
                        deliveries: [],
                        disinfections: [],
                        feeds: [],
                        treatments: []
                    },{
                        broodNumber: 3,
                        comments: [],
                        days: [],
                        deliveries: [],
                        disinfections: [],
                        feeds: [],
                        treatments: []
                    }]
                },{
                    name: 'Test house 2',
                    address: 'foo',
                    zipcode: '',
                    silos: [],
                    broods: [{
                        broodNumber: 1,
                        comments: [],
                        days: [],
                        deliveries: [],
                        disinfections: [],
                        feeds: [],
                        treatments: []
                    },{
                        broodNumber: 2,
                        comments: [],
                        days: [],
                        deliveries: [],
                        disinfections: [],
                        feeds: [],
                        treatments: []
                    },{
                        broodNumber: 3,
                        comments: [],
                        days: [],
                        deliveries: [],
                        disinfections: [],
                        feeds: [],
                        treatments: []
                    }]
                }]
            }, {
                name: 'Test farm 1',
                address: 'foo',
                zipcode: '3158',
                houses: [{
                    name: 'Test house 1',
                    address: 'foo',
                    zipcode: '',
                    silos: [],
                    broods: [{
                        broodNumber: 1,
                        comments: [],
                        days: [],
                        deliveries: [],
                        disinfections: [],
                        feeds: [],
                        treatments: []
                    },{
                        broodNumber: 2,
                        comments: [],
                        days: [],
                        deliveries: [],
                        disinfections: [],
                        feeds: [],
                        treatments: []
                    },{
                        broodNumber: 3,
                        comments: [],
                        days: [],
                        deliveries: [],
                        disinfections: [],
                        feeds: [],
                        treatments: []
                    }]
                },{
                    name: 'Test house 2',
                    address: 'foo',
                    zipcode: '',
                    silos: [],
                    broods: [{
                        broodNumber: 1,
                        comments: [],
                        days: [],
                        deliveries: [],
                        disinfections: [],
                        feeds: [],
                        treatments: []
                    },{
                        broodNumber: 2,
                        comments: [],
                        days: [],
                        deliveries: [],
                        disinfections: [],
                        feeds: [],
                        treatments: []
                    },{
                        broodNumber: 3,
                        comments: [],
                        days: [],
                        deliveries: [],
                        disinfections: [],
                        feeds: [],
                        treatments: []
                    }]
                }]
            }]
        };
    }
}
