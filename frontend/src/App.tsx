import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import SignInPage from "./pages/SignInPage/SignInPage";
import { useSyncExternalStore } from "react";
import { isLoggedIn , subscribe } from "./utils/session";
import PageLayout from "./components/PageLayout/PageLayout";
import { ROUTES } from "./constants/general";

function App() {
    const authenticated = useSyncExternalStore(
        subscribe,
        isLoggedIn 
    );
    
    return (
        <BrowserRouter>
            <Routes>
                <Route 
                    path={ROUTES.signIn}
                    element={!authenticated ? <SignInPage /> : <Navigate to={ROUTES.home} replace />}
                />
                <Route
                    path={ROUTES.home}
                    element={authenticated ? <PageLayout>Home Content</PageLayout> : <Navigate to={ROUTES.signIn} replace />}
                />
            </Routes>
        </BrowserRouter>
    );
}

export default App;