import React, {Component} from 'react';
import {Header, Button} from 'semantic-ui-react';

import './ExerciseVariantDetails.scss';
import CodeWindow from '../../components/Modules/CodeWindow';

class ExerciseVariantDetails extends Component {

    componentDidMount = () => {
        console.log(this.props.match.params.exerciseVariantID);
    }


    render() {
        //zmienianie string na html
        // const htmlString = '<div>Hello World</div>';
        // const v = 6;
        // function createMarkup() {
        //     return {__html: htmlString};
        //   }
        const addvariantcode = () => {
            console.log("Added");
        }
        const checkvariantcode = () => {
            console.log("Checked");
        }

        return (
            <div className='variantcontainer'>
                <div className='variantCodingContainer'>
                    <Header size='large'>Wariant: 1</Header>
                    {/*<div dangerouslySetInnerHTML={createMarkup()} />*/}
                    <div className="variantCodingContent">
                        <CodeWindow changeModeHTML={true} code={'Hello'} />
                        <div className="variantCodingButtons">
                            <Button primary onClick={addvariantcode}>Dodaj</Button>
                            <Button onClick={checkvariantcode}>Podejrzyj</Button>
                        </div>

                    </div>

                </div>
            </div>

        );
    }
}

export default ExerciseVariantDetails;