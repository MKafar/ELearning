import React, {Component} from 'react';
import {Header, Button} from 'semantic-ui-react';

import './ExerciseVariantDetails.scss';
import CodeWindow from '../../components/Modules/CodeWindow';

class ExerciseVariantDetails extends Component {

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

        return (
            <div className='variantcontainer'>
                <div className='variantCodingContainer'>
                    <Header size='large'>Wariant: 1</Header>
                    {/*<div dangerouslySetInnerHTML={createMarkup()} />*/}
                    <CodeWindow changeModeHTML={true}  code={'Hello'} />
                    <Button onClick={addvariantcode}>Dodaj</Button>
                </div>
            </div>

        );
    }
}

export default ExerciseVariantDetails;