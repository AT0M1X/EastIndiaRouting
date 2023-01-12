import styled from 'styled-components'

const FLabel = styled.label`
  display: inline-block;
  font-size: 1.6rem;
  line-height: 2.4rem;
  font-weight: 600;
  color: #1a1a1a;
  text-transform: none;
  padding-top: 1.5rem;
  padding-bottom: 1.5rem;
  padding-right: 4px;
  padding-left: 10px;
  max-width: 200px;
  width: 200px;
`

const BaseInput = styled.input.attrs((props) => ({
    type: props.type || 'text',
    name: props.name,
    onChange: props.onChange,
    value: props.value,
  }))`
    appearance: none;
    color: #1a1a1a;
    display: block;
    font-size: 1.6rem;
    line-height: 2.4rem;
    padding: calc(8px - 1px) calc(16px - 1px);
    width: 100%;
    max-width: 40rem;
    margin-top: 8px;
    margin-bottom: 8px;
    text-align: left;
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

const InputContainer = styled.div`
  display: flex;
  max-width: 150px;
  width: auto;
`
const TextInput = styled(BaseInput).attrs((props) => ({
    type: 'text',
  }))`
    border: 1px solid #747474;
    border-radius: 4px;
  `

const PackageInfoContainer = styled.div`
  max-width: 500px;
  width: auto;
  background-color: #22AAA1;
  border-radius: 10px;
  margin: auto;
`
  
const FormLabel = (props) => {
    const { text } = props
    return <FLabel>{text}</FLabel>
  }

interface CustomerInfo {
    Customer?: string | undefined
    Phone?: string | undefined
    EMail?: string | undefined
  }

interface WhoComponentProps {
    Customer?: CustomerInfo
    handleInputChange?: (event: React.KeyboardEvent, value: string) => void
  }

const WhoComponent = (props: WhoComponentProps) => {
    const { Customer, handleInputChange } = props

    return (
        <PackageInfoContainer>
            <RowContainer>
            <Content>
                  <FormLabel text={'Sender:'} />
                  <InputContainer>
                    <TextInput
                      onChange={handleInputChange}
                      name={'Customer'}
                      value={Customer?.Customer}
                    />
                  </InputContainer>
                </Content>
              </RowContainer>
              <RowContainer>
                <Content>
                  <FormLabel text={'Phone No:'} />
                  <InputContainer>
                    <TextInput
                      onChange={handleInputChange}
                      name={'Phone'}
                      value={Customer?.Phone}
                    />
                  </InputContainer>
                </Content>
              </RowContainer>
              <RowContainer>
                <Content>
                  <FormLabel text={'E-Mail:'} />
                  <InputContainer>
                    <TextInput
                      onChange={handleInputChange}
                      name={'EMail'}
                      value={Customer?.EMail}
                    />
                  </InputContainer>
                </Content>
              </RowContainer>
        </PackageInfoContainer>
        
    )
}

export default WhoComponent