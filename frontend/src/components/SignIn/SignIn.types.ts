import type { AuthResponseDto } from "../../models/auth.types";

export interface SignInProps{
    onSignInSuccess: (data: AuthResponseDto) => void;
}

export interface SignInFormState {
    email: string;
    password: string;
}