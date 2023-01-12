import {useState} from "react";
import styled from 'styled-components';



const RowContainer = styled.div`
  display: flex;
  flex-direction: row;
  margin-top: 5px;
  margin-bottom: 5px;
  `

const OutputContainer = styled.div`
  display: grid;
  grid-template-areas: 
            "title"
            "value";
  max-width: 150px;
  width: auto;
`

const TitleValue = styled.div`
  grid-area: "title";
`

const OutputValue = styled.div`
  grid-area: "value";
`

interface PriceAndRouteProps {
    from: string;
    to: string;
    price: number;
    duration: number;
};

const PriceAndRouteComponent = (props: PriceAndRouteProps) => {
    const {from, to, price, duration} = props;

    return (
        <RowContainer>
            <OutputContainer>
                <TitleValue> Route </TitleValue>
                <OutputValue>`${from} - ${to}`</OutputValue>
            </OutputContainer>
            <OutputContainer>
                <TitleValue> Price </TitleValue>
                <OutputValue>{price}</OutputValue>
            </OutputContainer>
            <OutputContainer>
                <TitleValue> Time </TitleValue>
                <OutputValue>`${duration} hours`</OutputValue>
            </OutputContainer>
        </RowContainer>
    );
};

export default PriceAndRouteComponent;