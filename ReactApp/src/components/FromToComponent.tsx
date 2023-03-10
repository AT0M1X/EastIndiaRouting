import { FunctionComponent, PropsWithChildren } from "react";
import Footer from "./Footer";
import HeaderComponent from "./HeaderComponent";
import map from '../assets//img/map.png';
import styled from "styled-components";
import {CityDto} from "../services/swaggerapi/data-contracts";
import CityInput from "./FromToComponents/CityInput";
import CityDropdown from "./FromToComponents/CityDropdown";
import logo from "../assets/img/logo_2.png";


interface CityComponentProps {
    Cities: Array<CityDto>
    From: string
    To: string
    onSelectFromClick: (e: React.ChangeEvent<HTMLSelectElement>) => void
    onSelectToClick: (e: React.ChangeEvent<HTMLSelectElement>) => void
}

const FromToComponent = (cityProps: CityComponentProps) => {
    const { Cities, onSelectFromClick, onSelectToClick, From, To} = cityProps;
    return (
        <Container>
            <CityInput From={From} To={To} cities={Cities} onSelectFromClick={onSelectFromClick} onSelectToClick={onSelectToClick}/>
            <Map2></Map2>
        </Container>
    );
};
const Container = styled.div`
   margin: 10px;
   display: flex;
   flex-direction: row;
`

const Map = styled.img`
  border: 2px;
  border-color: white;
`;

const Map2 = styled.div`

  background-image: url(${map});
  background-repeat: no-repeat;
  width: 420px;
  height: 611px;
  background-size: cover;
  margin: auto;
`;

export default FromToComponent;


