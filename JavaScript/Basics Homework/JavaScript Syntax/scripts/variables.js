function variablesTypes(array){
    return "\"My name: " + array[0] + " //type is "+typeof(array[0])+ "\n"+
    "My age: "+ array[1]+" //type is " + typeof (array[1]) + "\n"+
    "I am male: "+array[2]+" //type is "+ typeof (array[2])+ "\n"+
    "My favorite foods are: "+ array[3].join(',') +"\n//type is "+ typeof (array[3])+ "\"";
}
console.log(variablesTypes(['Pesho', 22, true, ['fries', 'banana', 'cake']]));