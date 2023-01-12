import { FunctionComponent, PropsWithChildren } from "react";
import Footer from "./Footer";
import HeaderComponent from "./HeaderComponent";

type Pageprops = {
  headerTitle: string;
};

const Page = (props: PropsWithChildren<Pageprops>) => {
  const children = props.children;
  return (
    <div>
      <HeaderComponent title={props.headerTitle} />
      {children}
      <Footer />
    </div>
  );
};

export default Page;
