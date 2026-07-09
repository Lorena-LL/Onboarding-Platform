import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import SignInPage from "./pages/SignInPage";
import { useSyncExternalStore } from "react";
import { getSnapshot, subscribe } from "./utils/session";
import Header from "./components/Header/Header";

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
                    element={authenticated ? <Header /> : <Navigate to="/" replace />}
                />
            </Routes>
        </BrowserRouter>
    );
}

export default App;