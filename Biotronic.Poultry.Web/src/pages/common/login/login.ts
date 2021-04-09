export class Login {
    public signinSuccess(user){
        console.log(user);
    }

    public signinError(error){
        console.warn(error);
    }
}
