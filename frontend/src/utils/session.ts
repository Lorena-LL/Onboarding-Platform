import { TOKEN_KEY, USER_ID_KEY } from "../constants/general";

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

export const getUserId = (): string | null => sessionStorage.getItem(USER_ID_KEY);

export const setUserId = (userId: string): void => {
    sessionStorage.setItem(USER_ID_KEY, userId);
};

export const clearUserId = (): void => {
    sessionStorage.removeItem(USER_ID_KEY);
};

export const signOut = (): void => {
    sessionStorage.removeItem(TOKEN_KEY);
    sessionStorage.removeItem(USER_ID_KEY);
    notify();
};