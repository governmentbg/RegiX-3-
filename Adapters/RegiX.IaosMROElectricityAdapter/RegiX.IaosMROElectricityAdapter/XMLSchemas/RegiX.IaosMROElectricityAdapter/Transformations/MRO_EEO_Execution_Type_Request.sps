<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="common" uri="http://egov.bg/RegiX/IAOS/Common"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/IAOS/ExecutionTypeRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.IaosMROElectricityAdapter\XMLSchemas\MRO_EEO_Execution_Type_Request.xsd" workingxmlfile="MRO_EEO_Execution_Type_Request.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<newline/>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Заявка за изготвяне на справка за начин на изпълнение в Регистър на лицата, които пускат на пазара електрическо и електронно оборудване (ЕЕО)."/>								</children>							</paragraph>							<newline/>							<newline/>							<table>								<properties align="center" border="0" width="100%"/>								<styles width="50%"/>								<children>									<tablebody>										<children>											<tablerow>												<children>													<tablecell>														<children>															<text fixtext="Единен идентификационен код (ЕИК)">																<styles font-weight="bold"/>															</text>														</children>													</tablecell>													<tablecell>														<children>															<template match="n1:MRO_EEO_Execution_Type_Request" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<template match="n1:EIK" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<format datatype="integer"/>																			</content>																		</children>																	</template>																</children>															</template>														</children>													</tablecell>												</children>											</tablerow>										</children>									</tablebody>								</children>							</table>							<newline/>							<newline/>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>