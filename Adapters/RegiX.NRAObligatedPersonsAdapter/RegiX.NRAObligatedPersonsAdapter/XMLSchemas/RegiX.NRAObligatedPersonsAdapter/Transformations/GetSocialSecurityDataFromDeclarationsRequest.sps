<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/NRA/SocialSecurityDataFromDeclarations/Request"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.NRAObligatedPersonsAdapter\XMLSchemas\GetSocialSecurityDataFromDeclarationsRequest.xsd" workingxmlfile="GetSocialSecurityDataFromDeclarationsRequest.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Входни параметри на Справка с данни за осигурените лица от подадени декларации по Наредба Н-13 към Кодекса за социално осигуряване"/>								</children>							</paragraph>							<template match="n1:GetSocialSecurityDataFromDeclarationsRequest" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<newline/>									<template match="n1:PersonIdentifier" matchtype="schemagraphitem">										<editorproperties elementstodisplay="5"/>										<children>											<text fixtext="Идентификатор за осигуреното физическо лице – с ограничение до 10 разряда:">												<styles font-style="italic"/>											</text>											<text fixtext=" "/>											<content>												<styles font-weight="bold"/>												<format datatype="string"/>											</content>										</children>									</template>									<newline/>									<template match="n1:PersonIdentifierType" matchtype="schemagraphitem">										<editorproperties elementstodisplay="5"/>										<children>											<text fixtext="Тип на идентификатор на физическо лице:">												<styles font-style="italic"/>											</text>											<text fixtext=" "/>											<condition>												<children>													<conditionbranch xpath=". = &apos;EGN&apos;">														<children>															<text fixtext="ЕГН">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath=". =&apos;LNCh&apos;">														<children>															<text fixtext="ЛНЧ">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath=". =&apos;NRASystemNo&apos;">														<children>															<text fixtext="Служебен номер от регистъра на НАП">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath=". =&apos;EIK_BULSTAT&apos;">														<children>															<text fixtext="ЕИК по БУЛСТАТ">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>												</children>											</condition>										</children>									</template>									<newline/>									<template match="n1:InsurerIdentificator" matchtype="schemagraphitem">										<editorproperties elementstodisplay="5"/>										<children>											<text fixtext="Идентификатор на осигурителя (ЕИК/сл.№ от регистъра на НАП)">												<styles font-style="italic"/>											</text>											<text fixtext=": "/>											<content>												<styles font-weight="bold"/>												<format datatype="string"/>											</content>										</children>									</template>									<newline/>									<template match="n1:MonthFrom" matchtype="schemagraphitem">										<editorproperties elementstodisplay="5"/>										<children>											<text fixtext="Месец от: ">												<styles font-style="italic"/>											</text>											<condition>												<children>													<conditionbranch xpath="contains(   .   , 05 )">														<children>															<text fixtext="май">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 06 )">														<children>															<text fixtext="юни">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 04 )">														<children>															<text fixtext="април">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 03 )">														<children>															<text fixtext="март">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , &apos;02&apos; )">														<children>															<text fixtext="февруари">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , &apos;01&apos;)">														<children>															<text fixtext="януари">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 07 )">														<children>															<text fixtext="юли">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 08 )">														<children>															<text fixtext="август">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 09 )">														<children>															<text fixtext="септември">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 10)">														<children>															<text fixtext="октомври">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 11 )">														<children>															<text fixtext="ноември">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 12 )">														<children>															<text fixtext="декември">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>												</children>											</condition>										</children>									</template>									<newline/>									<template match="n1:YearFrom" matchtype="schemagraphitem">										<editorproperties elementstodisplay="5"/>										<children>											<text fixtext="Година от:">												<styles font-style="italic"/>											</text>											<text fixtext=" "/>											<content>												<styles font-weight="bold"/>												<format datatype="gYear"/>											</content>										</children>									</template>									<newline/>									<template match="n1:MonthTo" matchtype="schemagraphitem">										<editorproperties elementstodisplay="5"/>										<children>											<text fixtext="Месец до: ">												<styles font-style="italic"/>											</text>											<condition>												<children>													<conditionbranch xpath="contains(   .   , 05 )">														<children>															<text fixtext="май">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 06 )">														<children>															<text fixtext="юни">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 04 )">														<children>															<text fixtext="април">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 03 )">														<children>															<text fixtext="март">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , &apos;02&apos; )">														<children>															<text fixtext="февруари">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , &apos;01&apos;)">														<children>															<text fixtext="януари">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 07 )">														<children>															<text fixtext="юли">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 08 )">														<children>															<text fixtext="август">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 09 )">														<children>															<text fixtext="септември">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 10)">														<children>															<text fixtext="октомври">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 11 )">														<children>															<text fixtext="ноември">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>													<conditionbranch xpath="contains(  .  , 12 )">														<children>															<text fixtext="декември">																<styles font-weight="bold"/>															</text>														</children>													</conditionbranch>												</children>											</condition>										</children>									</template>									<newline/>									<template match="n1:YearTo" matchtype="schemagraphitem">										<editorproperties elementstodisplay="5"/>										<children>											<text fixtext="Година до: ">												<styles font-style="italic"/>											</text>											<content>												<styles font-weight="bold"/>												<format datatype="gYear"/>											</content>										</children>									</template>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>