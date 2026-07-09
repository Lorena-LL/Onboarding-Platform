import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import SignInPage from "./pages/SignInPage";
import { useSyncExternalStore } from "react";
import { getSnapshot, subscribe } from "./utils/session";
import PageLayout from "./components/PageLayout/PageLayout";

function App() {
    const authenticated = useSyncExternalStore(
        subscribe,
        getSnapshot
    );
    
    return (
        <BrowserRouter>
            <Routes>
                <Route 
                    path="/"
                    element={!authenticated ? <SignInPage /> : <Navigate to="/home" replace />}
                />
                <Route
                    path="/home"
                    element={authenticated ? <PageLayout>Home Content</PageLayout> : <Navigate to="/" replace />}
                />
            </Routes>
        </BrowserRouter>
    );
}

export default App;