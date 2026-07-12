import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import SignInPage from "./pages/SignInPage/SignInPage";
import { useSyncExternalStore } from "react";
import { isLoggedIn , subscribe } from "./utils/session";
import PageLayout from "./components/PageLayout/PageLayout";
import { ROUTES } from "./constants/general";
import ProfilePage from "./pages/ProfilePage/ProfilePage";
import ActiveTasksPage from "./pages/ActiveTasksPage/ActiveTasksPage";
import CompletedTasksPage from "./pages/CompletedTasksPage/CompletedTasksPage";

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
                <Route
                    path={ROUTES.profile}
                    element={authenticated 
                        ? <PageLayout><ProfilePage /></PageLayout> 
                        : <Navigate to={ROUTES.signIn} replace />}
                />
                <Route
                    path={ROUTES.activeTasks}
                    element={authenticated 
                        ? <PageLayout><ActiveTasksPage /></PageLayout>
                        : <Navigate to={ROUTES.signIn} replace />}
                />
                <Route
                    path={ROUTES.completedTasks}
                    element={authenticated 
                        ? <PageLayout><CompletedTasksPage /></PageLayout>
                        : <Navigate to={ROUTES.signIn} replace />}
                />
            </Routes>
        </BrowserRouter>
    );
}

export default App;