import styled from 'styled-components'
import CityDropdown from "./CityDropdown";
import {CityDto} from "../../services/swaggerapi/data-contracts";

const FLabel = styled.label`
  display: inline-block;
  font-size: 1.4rem;
  line-height: 0.2rem;
  font-weight: 600;
  color: #1a1a1a;
  text-transform: none;
  padding-top: 1.5rem;
  padding-bottom: 1.5rem;
  padding-right: 4px;
  padding-left: 10px;
  max-width: 100px;
  width: 100px;
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
    font-size: 1.3rem;
    line-height: 1.2rem;
    padding: calc(8px - 1px) calc(16px - 1px);
    width: 100%;
    max-width: 20rem;
    margin-top: 8px;
    margin-bottom: 8px;
    text-align: left;
  `

const RowContainer = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: baseline;
  margin-top: 5px;
  margin-bottom: 5px;
  `

const Content = styled.div`
  padding-right: 12px;
  display: flex;
  width: inherit;
`

const InputContainer = styled.div`
  width: auto;
`
const TextInput = styled(BaseInput).attrs((props) => ({
    type: 'text',
}))`
    border: 1px solid #747474;
    border-radius: 4px;
  `

const CityContainer = styled.div`
  max-width: 300px;
  width: auto;
  background-color: #22AAA1;
  border-radius: 10px;
`

const FormLabel = (props) => {
    const { text } = props
    return <FLabel>{text}</FLabel>
}

interface CityInputProps {
    cities: Array<CityDto>
    onSelectFromClick: (e: React.ChangeEvent<HTMLSelectElement>) => void
    onSelectToClick: (e: React.ChangeEvent<HTMLSelectElement>) => void
}

const CityInput = (props: CityInputProps) => {
    const {cities, onSelectFromClick, onSelectToClick} = props

    return (
            <RowContainer>
                <Content>
                    <FormLabel text={'From:'} />
                    <InputContainer>
                        <CityDropdown Cities={cities} onSelectClick={onSelectFromClick}/>
                    </InputContainer>
                </Content>
                <Content>
                    <FormLabel text={'To:'} />
                    <InputContainer>
                        <CityDropdown Cities={cities} onSelectClick={onSelectToClick}/>
                    </InputContainer>
                </Content>
            </RowContainer>

    )
}

export default CityInput