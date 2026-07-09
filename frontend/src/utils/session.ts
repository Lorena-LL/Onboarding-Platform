import { TOKEN_KEY } from "../constants/general";

export const getToken = (): string | null => sessionStorage.getItem(TOKEN_KEY);

export const setToken = (token: string): void => {
    sessionStorage.setItem(TOKEN_KEY, token);
};

export const clearToken = (): void => {
    sessionStorage.removeItem(TOKEN_KEY);
};

export const isLoggedIn = (): boolean => getToken() !== null;