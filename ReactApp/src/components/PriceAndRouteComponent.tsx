import {useState} from "react";
import styled from 'styled-components';



const RowContainer = styled.div`
  display: flex;
  max-width: 600px;
  flex-direction: row;
  margin: auto;
  `

const OutputContainer = styled.div`
  max-width: 200px;
  width: 200px;
  border-radius: 10px;
  background-color: white;
  margin-top: 10px;
  margin-bottom: 10px;
  margin-left: 10px;
  margin-right: 10px;
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
    costCompetitors: number;
};

const PriceAndRouteComponent = (props: PriceAndRouteProps) => {
    const {from, to, price, duration, costCompetitors} = props;
    console.info(price);
    return (
        <RowContainer>
            <OutputContainer>
                <TitleValue> Route </TitleValue>
                <OutputValue>{`${from} - ${to}`}</OutputValue>
            </OutputContainer>
            <OutputContainer>
                <TitleValue> Price </TitleValue>
                <OutputValue>{`${price} $`}</OutputValue>
            </OutputContainer>
            <OutputContainer>
                <TitleValue> Time </TitleValue>
                <OutputValue>{`${duration} hours`}</OutputValue>
            </OutputContainer>
            <OutputContainer>
                <TitleValue> Cost to competitors </TitleValue>
                <OutputValue>{`${costCompetitors} $`}</OutputValue>
            </OutputContainer>
        </RowContainer>
    );
};

export default PriceAndRouteComponent;