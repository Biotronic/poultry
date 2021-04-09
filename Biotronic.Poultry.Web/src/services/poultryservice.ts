import "date-fns"
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
}
