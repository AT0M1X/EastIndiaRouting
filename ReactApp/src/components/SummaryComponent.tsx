import styled from 'styled-components'

interface SummaryProps {
    OrderID: string
    Package: string
    Route: string
    Prices: string
    Customer: string
}

const SummaryInfoContainer = styled.div`
  max-width: 500px;
  width: auto;
  background-color: light-gray;
  border-radius: 10px;
  margin: auto;
`

const RowContainer = styled.div`
  display: flex;
  flex-direction: row;
  margin-top: 5px;
  margin-bottom: 5px;
  `

  const Content = styled.div`
  padding-right: 12px;
  display: flex;
  width: inherit;
`
const FLabel = styled.label`
  display: inline-block;
  font-size: 1.6rem;
  line-height: 2.4rem;
  font-weight: 600;
  color: #1a1a1a;
  text-transform: none;
  padding-top: 0.5rem;
  padding-bottom: 0.5rem;
  padding-right: 4px;
  padding-left: 10px;
  max-width: 400px;
  width: 400px;
`

const FormLabel = (props) => {
    const { text } = props
    return <FLabel>{text}</FLabel>
  }

const SummaryComponent = (props: SummaryProps) => {
    const { OrderID, Package, Route, Prices, Customer } = props
    return (
        <SummaryInfoContainer>
            <RowContainer>
            <Content>
                  <FormLabel text={`Order ID: ${OrderID}`} />
                </Content>
              </RowContainer>
              <RowContainer>
            <Content>
                  <FormLabel text={`Package: ${Package}`} />
                </Content>
              </RowContainer>
              <RowContainer>
            <Content>
                  <FormLabel text={`Route: ${Route}`} />
                </Content>
              </RowContainer>
              <RowContainer>
            <Content>
                  <FormLabel text={`Price: ${Prices}`} />
                </Content>
              </RowContainer>
              <RowContainer>
            <Content>
                  <FormLabel text={`Customer: ${Customer}`} />
                </Content>
              </RowContainer>
        </SummaryInfoContainer>
    )
}

export default SummaryComponent;