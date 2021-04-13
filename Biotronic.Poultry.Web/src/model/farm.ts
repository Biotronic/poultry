export interface IFarm {
    name: string;
    address: string;
    zipcode: string;

    houses: IHouse[];
}

export interface IHouse {
    name: string;
    address: string;
    zipcode: string;
    broods: IBrood[];
    silos: ISilo[];
}

export interface IBrood {
    broodNumber: number;
    received?: Date;
    ended?: Date;
    veterinarian?: IUser[];
    hatchery?: IHatchery;
    maleCount?: number;
    femaleCount?: number;
    hybrid?: IHybrid;
    days: IDayRecord[];
    comments: IBroodComment[];
    disinfections: IBroodDisinfection[];
    feeds: IBroodFeed[];
    treatments: IBroodTreatment[];
    deliveries: IBroodDelivery[];
}

export interface ISilo { }
export interface IUser { }
export interface IHatchery { }
export interface IHybrid { }
export interface IDayRecord { }
export interface IBroodComment { }
export interface IBroodDisinfection { }
export interface IBroodFeed { }
export interface IBroodTreatment { }
export interface IBroodDelivery { }

export interface IMessage<T> {
    value: T;
}
