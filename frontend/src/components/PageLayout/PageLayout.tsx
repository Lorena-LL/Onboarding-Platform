import Header from "../Header/Header";
import type { PageLayoutProps } from "./PageLayout.types";
import SidePanel from "../SidePanel/SidePanel";
import "./PageLayout.css";

const PageLayout: React.FC<PageLayoutProps> = ({ children }: PageLayoutProps) => {
    return (
        <div className="page-layout">
            <Header />
            <div className="page-layout__body">
                <SidePanel />
                <main className="page-layout__content">{children}</main>
            </div>
        </div>
    );
}

export default PageLayout;