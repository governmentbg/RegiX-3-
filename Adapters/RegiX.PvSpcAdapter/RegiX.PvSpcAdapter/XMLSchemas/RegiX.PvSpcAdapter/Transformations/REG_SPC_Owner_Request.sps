<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/PatentDepartment/SPC/SPCOwnerRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.PvSpcAdapter\XMLSchemas\REG_SPC_Owner_Request.xsd" workingxmlfile="REG_SPC_Owner_Request.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<newline/>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Справка по притежател на сертификат за допълнителна закрила"/>								</children>							</paragraph>							<newline/>							<table>								<properties align="center" border="0" width="100%"/>								<styles width="50%"/>								<children>									<tablebody>										<children>											<tablerow>												<children>													<tablecell>														<children>															<text fixtext="Име">																<styles font-weight="bold"/>															</text>														</children>													</tablecell>													<tablecell>														<children>															<template match="n1:getSPCByOwnersName" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<template match="n1:FirstName" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</template>														</children>													</tablecell>												</children>											</tablerow>											<tablerow>												<children>													<tablecell>														<children>															<text fixtext="Презиме">																<styles font-weight="bold"/>															</text>														</children>													</tablecell>													<tablecell>														<children>															<template match="n1:getSPCByOwnersName" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<template match="n1:Surname" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</template>														</children>													</tablecell>												</children>											</tablerow>											<tablerow>												<children>													<tablecell>														<children>															<text fixtext="Фамилия">																<styles font-weight="bold"/>															</text>														</children>													</tablecell>													<tablecell>														<children>															<template match="n1:getSPCByOwnersName" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<template match="n1:LastName" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</template>														</children>													</tablecell>												</children>											</tablerow>										</children>									</tablebody>								</children>							</table>							<newline/>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>