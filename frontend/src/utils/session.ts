import { TOKEN_KEY } from "../constants/general";

export const isLoggedIn = (): boolean => getToken() !== null;

const listeners = new Set<() => void>();

export const subscribe = (listener: () => void) => {
    listeners.add(listener);
    return () => listeners.delete(listener);
};

const notify = () => {
    listeners.forEach(l => l());
};

export const getToken = (): string | null => sessionStorage.getItem(TOKEN_KEY);

export const setToken = (token: string): void => {
    sessionStorage.setItem(TOKEN_KEY, token);
    notify();
};

export const clearToken = (): void => {
    sessionStorage.removeItem(TOKEN_KEY);
    notify();
};