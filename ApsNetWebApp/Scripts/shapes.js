function validation() {
    var val1 = document.getElementById("inputBox");
    var val2 = 'Draw';
    var str1 = val1.split(' ');
        for (var i = 0; i < str1.length; i++) {
            if (str1[0] === val2) {
                return true
            }
            else {
                alert('invalid string entered');
            }
            
            
        }
    
};